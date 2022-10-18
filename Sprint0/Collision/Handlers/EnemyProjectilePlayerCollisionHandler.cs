
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

namespace Sprint0.Collision.Handlers
{
    // TODO: need to refactor class name (order unintuitive)
    // Handles all collisions where the affected object is an item and the acting object is the player
    public class EnemyProjectilePlayerCollisionHandler
    {
        private Room Room;

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
            projectile.TimeIsUp();
            // Add shield logic
            if (player.IsStationary && player.FacingDirection == projectileSide)
            {
                // Damage blocked
                // Need to fix: Link continues to take damage as porjectile passes through shield
                System.Diagnostics.Debug.WriteLine("BLOCK!");
                projectile.TimeIsUp();
            }
            // Add logic if shield if implemented
            else
            { 
                new PlayerTakeDamageCommand(player).Execute();
            }
        }
    }
}
