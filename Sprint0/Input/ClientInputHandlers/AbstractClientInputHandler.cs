using System;
using System.Collections.Generic;
using Sprint0.Commands;

namespace Sprint0.Input.ClientInputHandlers
{
    public abstract class AbstractClientInputHandler : IInputHandler
    {
        // we use targeted commands to allow the server to terget specific
        // players by their inputId
        protected Dictionary<String, ITargetedCommand> buttonPressMap;
        protected Dictionary<String, ITargetedCommand> buttonReleaseMap;
        protected LoadableSet<ClientInputDispatch<String>> keysPressed;

        public AbstractClientInputHandler()
        {
            buttonPressMap = new Dictionary<string, ITargetedCommand>();
            buttonReleaseMap = new Dictionary<string, ITargetedCommand>();
            keysPressed = new LoadableSet<ClientInputDispatch<string>>();
        }

        public virtual void HandleInput(dynamic input, string id)
        {
            String inputType = input["type"];
            switch (inputType)
            {
                case "buttonPress":
                    {
                        String button = input["button"];
                        button = button.ToLower();

                        // by staging the asynchronous updates, we can integrate them into the single threaded game loop
                        // with the Load() method inside Update().  It also prevents the list from
                        // updating while using an IEnumerable

                        //add to the list if it doesn't already exist
                        if (!keysPressed.Exists(e => e.inputId == id && e.input == button)) keysPressed.StagePut(new ClientInputDispatch<string>(id, button));
                        break;
                    }

                case "buttonRelease":
                    {
                        String button = input["button"];
                        button = button.ToLower();

                        // since the web server batches requests for efficiency, if a button
                        // is pressed and released quickly, the two signals can get batched.
                        // To ensure that all input is processed, we keep all button presses
                        // alive for at least one frame, regardless of when it was released.
                        // This functionality is assisted by the helper class LoadableSet.

                        // stage a drop if it is in the list
                        if (keysPressed.Exists(e => e.inputId == id && e.input == button)) keysPressed.StageDrop(new ClientInputDispatch<string>(id, button));
                        break;
                    }

                // if the case is not used, ignore it
                default: break;
            }
        }

        public virtual void Update()
        {
            foreach (var dispatch in keysPressed)
            {
                if (buttonPressMap.ContainsKey(dispatch.input))
                {
                    buttonPressMap[dispatch.input].Execute();
                }
            }

            foreach (var dispatch in this.GetStagedKeyReleases())
            {
                if (buttonReleaseMap.ContainsKey(dispatch.input))
                {
                    buttonReleaseMap[dispatch.input].Execute();
                }
            }
            keysPressed.Load();
        }

        // key releases are staged in the keysPressed LoadableSet
        protected List<ClientInputDispatch<string>> GetStagedKeyReleases()
        {
            var drops = new List<ClientInputDispatch<String>>();
            foreach (var update in keysPressed.GetStagedUpdates())
            {
                if (update.updateType == UpdateType.Drop)
                {
                    drops.Add(update.element);
                }
            }
            return drops;
        }
    }
}

