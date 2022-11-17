using System;
using System.Collections.Generic;
using Sprint0.Commands;
using Sprint0.Commands.GameStates;

namespace Sprint0.GameStates.ClientInputHandlers
{
	public class MainMenuClientInputHandler : IInputHandler
	{
        private readonly Dictionary<String, ICommand> commandMap;
        private readonly LoadableSet<String> keysPressed;

		public MainMenuClientInputHandler(Game1 game1)
		{
            keysPressed = new LoadableSet<String>();
            commandMap = new Dictionary<String, ICommand>()
            {
                { " ", new StartGameCommand(game1) }
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
                        if (!keysPressed.Contains(button)) keysPressed.Put(button);
                        break;
                    }

                case "buttonRelease":
                    {
                        String button = input["button"];
                        // we want to drop the key press 1 frame later to ensure it is caught by Update()
                        if (keysPressed.Contains(button)) keysPressed.StageDrop(button);
                        break;
                    }

                // if the case is not used, ignore it
                default: break;
            }
        }

        public void Update()
        {
            foreach (var key in keysPressed)
            {
                if (commandMap.ContainsKey(key))
                {
                    commandMap[key].Execute();
                }
            }
            // drop any buttons that were staged upon release
            // Note: not strictly necessary here, but it's included for completeness
            keysPressed.Load();
        }
    }
}

