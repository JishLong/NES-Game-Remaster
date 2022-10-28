using Sprint0.Levels;
using Sprint0.Player;

namespace Sprint0.Collision
{
    // A simple way for the client Game1 class to set up collisions
    public class CollisionController : IController
    {
        private readonly Game1 Game;
        private readonly CollisionDetector CollisionDetector;

        public CollisionController(Game1 game) 
        {
            Game = game;
            CollisionDetector = new CollisionDetector(Game);
        }

        public void Update()
        {
            CollisionDetector.Update();
        }
    }
}
