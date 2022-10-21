
using Sprint0.Characters;
using Sprint0.Characters.Enemies;
using Sprint0.Commands.Levels;
using Sprint0.Items;
using Sprint0.Characters.Bosses;
using Sprint0.Commands.Characters;
using Sprint0.Commands.Player;
using Sprint0.Levels;
using Sprint0.Player;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Collision.Handlers
{
    // TODO: need to refactor class name (order unintuitive)
    // Handles all collisions where the affected object is an item and the acting object is the player
    public class EnemyProjectilePlayerCollisionHandler
    {
        private Room Room;
        private ProjectileManager ProjectileManager;

        public EnemyProjectilePlayerCollisionHandler(Room room)
        {
            Room = room;
        }

        /* NOTE: [itemSide] (aka the side of the item the collision is happening on) is used to determine player knockback
         * 
         */
        public void HandleCollision(IPlayer player, IProjectile projectile, Types.Direction projectileSide, Room room)
        {
            // Remove projectile
            ProjectileManager = ProjectileManager.GetInstance();
            ProjectileManager.RemoveProjectile(projectile);
            // Add shield logic
            if (player.IsStationary && player.FacingDirection == projectileSide)
            {
                // Need to fix: Link continues to take damage as projectile passes through shield
            }
            else
            { 
                new PlayerTakeDamageCommand(player, projectileSide).Execute();
            }
        }
    }
}
