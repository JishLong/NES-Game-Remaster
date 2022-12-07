using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using System.Collections.Generic;
using System.Drawing;

namespace Sprint0.Controllers
{
    public class MouseController : IController
    {
        private readonly Dictionary<string, ICommand> CommandMappings;
        private Game1 game;

        // Used so that only the "pulse" of the mouse is registered rather than just looking for the button held down
        private MouseState PrevState;

        public MouseController(Dictionary<string, ICommand> commandMappings, Game1 game1)
        {
            CommandMappings = commandMappings;
            PrevState = Mouse.GetState();
            this.game = game1;
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
            return Mouse.GetState().X >= 0 && Mouse.GetState().X <= game.GraphicsDevice.Viewport.Width &&
                   Mouse.GetState().Y >= 0 && Mouse.GetState().Y <= game.GraphicsDevice.Viewport.Height;
        }
    }
}
