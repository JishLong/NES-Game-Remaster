using System;
using System.Collections.Generic;
using Sprint0.Commands;
using Sprint0.Commands.GameStates;

namespace Sprint0.Input.ClientInputHandlers
{
	public class MainMenuClientInputHandler : AbstractClientInputHandler
	{
		public MainMenuClientInputHandler(Game1 game1)
		{
            buttonPressMap = new Dictionary<String, ITargetedCommand>()
            {
                { " ", new StartGameCommand(game1) }
            };
        }
    }
}

