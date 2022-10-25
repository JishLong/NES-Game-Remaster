using Sprint0.Levels;

namespace Sprint0.Projectiles.Tools
{
    /* The purpose of this class is to facilitate control over the projectile manager's ability to update projectiles;
     * 
     * This is done by keeping the projectile manager up to date with the current room the player is in - this way,
     * all the projectiles in only that room are updated and handled
     * 
     * This should be utilized as a controller in the Game1.cs class
     */
    public class ProjectileController : IController
    {
        private readonly LevelManager LevelManager;

        public ProjectileController(LevelManager levelManager)
        {
            LevelManager = levelManager;
        }

        public void Update()
        {
            ProjectileManager.GetInstance().SetCurrentRoom(LevelManager.CurrentLevel.CurrentRoom);
        }
    }
}
