﻿using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using System.Collections.Generic;

namespace Sprint0.Controllers
{
    public class MouseController : IController
    {
        private readonly Game1 Game;
        private readonly Dictionary<string, ICommand> CommandMappings;

        // Used so that only the "pulse" of the mouse is registered rather than just looking for the button held down
        private MouseState PrevState;

        public MouseController(Game1 game, Dictionary<string, ICommand> commandMappings)
        {
            Game = game;
            CommandMappings = commandMappings;
            PrevState = Mouse.GetState();
        }

        public void Update()
        {
            MouseState CurrentState = Mouse.GetState();

            // Handling of left click
            if (Game.IsActive && CurrentState.LeftButton == ButtonState.Pressed && PrevState.LeftButton == ButtonState.Released)
            {
                if (CommandMappings.ContainsKey("left")) CommandMappings["left"].Execute();
            }

            // Handling of right click
            if (Game.IsActive && CurrentState.RightButton == ButtonState.Pressed && PrevState.RightButton == ButtonState.Released)
            {
                if (CommandMappings.ContainsKey("right")) CommandMappings["right"].Execute();
            }

            PrevState = CurrentState;
        }
    }
}
