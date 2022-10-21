using System;
using Sprint0.Characters;
using Sprint0.Levels;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;

namespace Sprint0.Collision.Handlers
{
    public class PlayerProjEnemyCollisionHandler
    {
        public PlayerProjEnemyCollisionHandler()
        {
        }

        public void HandleCollision(IProjectile projectile, ICharacter character, Types.Direction projectileSide, Room room)
        {
            character.TakeDamage(projectileSide, 1, room);
            ProjectileManager.GetInstance().RemoveProjectile(projectile);
        }
    }
}

