using Sprint0.Levels;
using Sprint0.Player;

namespace Sprint0.Collision
{
    // A simple way for the client Game1 class to set up collisions
    public class CollisionController : IController
    {
        private LevelManager LevelManager;
        private CollisionDetector CollisionDetector;

        public CollisionController(LevelManager levelManager, IPlayer player) 
        {
            LevelManager = levelManager;
            CollisionDetector = new CollisionDetector(player);
        }

        public void Update()
        {
            CollisionDetector.Update(LevelManager.CurrentLevel.CurrentRoom);
        }
    }
}
