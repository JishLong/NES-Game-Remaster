
using Sprint0.Blocks;
using Sprint0.Characters;
using Sprint0.Characters.Enemies;
using Sprint0.Commands.Levels;
using Sprint0.Items;
using Sprint0.Blocks;
using Sprint0.Levels;
using Sprint0.Player;
using Sprint0.Projectiles;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions where the affected object is an item and the acting object is the player
    public class EnemyProjectileBlockCollisionHandler
    {
        private Room Room;

        public EnemyProjectileBlockCollisionHandler(Room room)
        {
            Room = room;
        }

        public void HandleCollision(IProjectile projectile, IBlock block, Types.Direction playerSide, Room room)
        {
            projectile.TimeIsUp();
        }
    }
}
