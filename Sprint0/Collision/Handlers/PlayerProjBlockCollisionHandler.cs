using System;
using Sprint0.Blocks;
using Sprint0.Levels;
using Sprint0.Player;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Collision.Handlers
{
    public class PlayerProjBlockCollisionHandler
    {
        public PlayerProjBlockCollisionHandler()
        {
        }

        public void HandleCollision(IProjectile projectile)
        {
            ProjectileManager.GetInstance().RemoveProjectile(projectile);
        }
    }
}

