using Microsoft.Xna.Framework.Input;
using Sprint0.Commands.Levels;

namespace Sprint0.Controllers
{
    public class MouseController : IController
    {
        private Game1 Game;

        // Used so that only the "pulse" of the mouse is registered rather than just looking for the button held down
        private MouseState PrevState;

        public MouseController(Game1 game)
        {
            Game = game;

            PrevState = Mouse.GetState();
        }

        public void Update()
        {
            MouseState CurrentState = Mouse.GetState();

            // Handling of left click
            if (CurrentState.LeftButton == ButtonState.Pressed && PrevState.LeftButton == ButtonState.Released)
            {
                new PreviousRoomCommand(Game).Execute();
            }

            // Handling of right click
            if (CurrentState.RightButton == ButtonState.Pressed && PrevState.RightButton == ButtonState.Released)
            {
                new NextRoomCommand(Game).Execute();
            }

            PrevState = CurrentState;
        }
    }
}
