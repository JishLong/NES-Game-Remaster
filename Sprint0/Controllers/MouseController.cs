using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using Sprint0.Commands.Player;

namespace Sprint0.Controllers
{
    public class MouseController : IController
    {
        private Game1 game;
        private GraphicsDeviceManager graphics;

        // Used so that only the "pulse" of the mouse is registered rather than just looking for the button held down
        private MouseState prevState;

        public MouseController(Game1 game, GraphicsDeviceManager graphics)
        {
            this.game = game;
            this.graphics = graphics;

            prevState = Mouse.GetState();
        }

        public void Update()
        {
            MouseState CurrentState = Mouse.GetState();

            // Handling of left click
            if (CurrentState.LeftButton == ButtonState.Pressed && prevState.LeftButton == ButtonState.Released)
            {
                
            }

            // Handling of right click
            if (CurrentState.RightButton == ButtonState.Pressed && prevState.RightButton == ButtonState.Released)
            {
                new QuitCommand(game).Execute();
            }

            prevState = CurrentState;
        }
    }
}
