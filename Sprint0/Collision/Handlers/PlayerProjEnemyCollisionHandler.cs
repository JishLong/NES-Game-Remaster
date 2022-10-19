using System;
using Sprint0.Characters;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Collision.Handlers
{
    public class PlayerProjEnemyCollisionHandler
    {
        public PlayerProjEnemyCollisionHandler()
        {
        }

        public void HandleCollision(IProjectile projectile, ICharacter character)
        {
            //TODO: cause character to take damage
            ProjectileManager.GetInstance().RemoveProjectile(projectile);
        }
    }
}

