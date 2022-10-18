
using Sprint0.Blocks;
using Sprint0.Levels;
using Sprint0.Projectiles;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions where the affected object is an item and the acting object is the player
    public class EnemyProjectileBlockCollisionHandler
    {
        private Room Room;
        private ProjectileManager ProjectileManager;
        public EnemyProjectileBlockCollisionHandler(Room room)
        {
            Room = room;
        }
        // Side is not used in this context.

        public void HandleCollision(IProjectile projectile, IBlock block, Types.Direction playerSide, Room room)
        {
            // Remove projectile
            ProjectileManager = ProjectileManager.GetInstance();
            ProjectileManager.AddProjectileToRemove(projectile);
            ProjectileManager.Update();
        }
    }
}
