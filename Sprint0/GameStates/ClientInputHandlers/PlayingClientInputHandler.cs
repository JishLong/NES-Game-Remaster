using System;
using System.Collections.Generic;
using Sprint0.Commands;
using Sprint0.Commands.Player;

namespace Sprint0.GameStates.ClientInputHandlers
{
	public class PlayingClientInputHandler : IInputHandler
	{
        private readonly Dictionary<String, ICommand> buttonPressMap;
        private readonly Dictionary<String, ICommand> buttonReleaseMap;
        private readonly LoadableSet<String> keysPressed;

        public PlayingClientInputHandler(Game1 game1)
		{
            keysPressed = new LoadableSet<string>();
            buttonPressMap = new Dictionary<string, ICommand>()
            {
                // player movement
                { "w", new PlayerMoveCommand(game1.PlayerManager.GetDefaultPlayer(), Types.Direction.UP) },
                { "a", new PlayerMoveCommand(game1.PlayerManager.GetDefaultPlayer(), Types.Direction.LEFT) },
                { "s", new PlayerMoveCommand(game1.PlayerManager.GetDefaultPlayer(), Types.Direction.DOWN) },
                { "d", new PlayerMoveCommand(game1.PlayerManager.GetDefaultPlayer(), Types.Direction.RIGHT) },
                { "arrow up", new PlayerMoveCommand(game1.PlayerManager.GetDefaultPlayer(), Types.Direction.UP) },
                { "arrow left", new PlayerMoveCommand(game1.PlayerManager.GetDefaultPlayer(), Types.Direction.LEFT) },
                { "arrow down", new PlayerMoveCommand(game1.PlayerManager.GetDefaultPlayer(), Types.Direction.DOWN) },
                { "arrow right", new PlayerMoveCommand(game1.PlayerManager.GetDefaultPlayer(), Types.Direction.RIGHT) },

                // player attack
                { "z", new PlayerSwordAttackCommand(game1.PlayerManager.GetDefaultPlayer()) },
                { "n", new PlayerSwordAttackCommand(game1.PlayerManager.GetDefaultPlayer()) },
            };

            buttonReleaseMap = new Dictionary<string, ICommand>()
            {
                // stop moving
                { "w", new PlayerStopActionCommand(game1.PlayerManager.GetDefaultPlayer()) },
                { "a", new PlayerStopActionCommand(game1.PlayerManager.GetDefaultPlayer()) },
                { "s", new PlayerStopActionCommand(game1.PlayerManager.GetDefaultPlayer()) },
                { "d", new PlayerStopActionCommand(game1.PlayerManager.GetDefaultPlayer()) },
                { "arrow up", new PlayerStopActionCommand(game1.PlayerManager.GetDefaultPlayer()) },
                { "arrow left", new PlayerStopActionCommand(game1.PlayerManager.GetDefaultPlayer()) },
                { "arrow down", new PlayerStopActionCommand(game1.PlayerManager.GetDefaultPlayer()) },
                { "arrow right", new PlayerStopActionCommand(game1.PlayerManager.GetDefaultPlayer()) }
            };
        }

        public void HandleInput(dynamic input)
        {
            String inputType = input["type"];
            switch (inputType)
            {
                case "buttonPress":
                    {
                        String button = input["button"];
                        button = button.ToLower();
                        if (!keysPressed.Contains(button)) keysPressed.Put(button);
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
                        if (keysPressed.Contains(button)) keysPressed.StageDrop(button);
                        break;
                    }

                // if the case is not recognized, the client is sending invalid input
                default: break;
            }
        }

        // key releases are staged in the keysPressed LoadableSet
        private List<String> GetStagedKeyReleases()
        {
            List<String> drops = new List<string>();
            foreach (var update in keysPressed.GetStagedUpdates())
            {
                if (update.updateType == UpdateType.Drop)
                {
                    drops.Add(update.element);
                }
            }
            return drops;
        }

        public void Update()
        {
            foreach (var key in keysPressed)
            {
                if (buttonPressMap.ContainsKey(key))
                {
                    buttonPressMap[key].Execute();
                }
            }

            foreach (var key in this.GetStagedKeyReleases())
            {
                if (buttonReleaseMap.ContainsKey(key))
                {
                    buttonReleaseMap[key].Execute();
                }
            }
            keysPressed.Load();
        }
    }
}

