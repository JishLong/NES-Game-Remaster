using Sprint0.Levels;
using Sprint0.Projectiles;
using Sprint0.Items;

namespace Sprint0.Collision.Handlers
{
    public class ProjectileItemCollisionHandler
    {
        public void HandleCollision(IProjectile projectile, IItem item, Types.Direction projectileSide)
        {
            // The player's boomerang can pick up items - cool trick! 
            if (projectile is BoomerangProjectile && projectile.IsFromPlayer()) (projectile as BoomerangProjectile).HoldItem(item);
        }
    }
}
