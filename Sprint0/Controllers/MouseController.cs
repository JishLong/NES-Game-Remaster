using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands.Player;

namespace Sprint0.Controllers
{
    public class MouseController : IController
    {
        private Game1 game;

        // Used to register mouse button presses/releases
        private MouseState prevState;

        public MouseController(Game1 game)
        {
            this.game = game;
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
