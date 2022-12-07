using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using System.Collections.Generic;
using System.Drawing;

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
            if (CurrentState.LeftButton == ButtonState.Pressed && PrevState.LeftButton == ButtonState.Released && MouseInWindow())
            {
                if (CommandMappings.ContainsKey("left")) CommandMappings["left"].Execute();
            }

            // Handling of right click
            if (CurrentState.RightButton == ButtonState.Pressed && PrevState.RightButton == ButtonState.Released && MouseInWindow())
            {
                if (CommandMappings.ContainsKey("right")) CommandMappings["right"].Execute();
            }

            PrevState = CurrentState;
        }

        private bool MouseInWindow()
        {
            return Mouse.GetState().X >= 0 && Mouse.GetState().X <= Game.GraphicsDevice.Viewport.Width &&
                   Mouse.GetState().Y >= 0 && Mouse.GetState().Y <= Game.GraphicsDevice.Viewport.Height;
        }
    }
}
