using Sprint0.Levels;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;
using Sprint0.Projectiles.Player_Projectiles;
using Sprint0.Characters;
using Sprint0.Commands.Characters;
using Sprint0.Npcs;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between characters and projectiles
    public class CharacterProjectileCollisionHandler
    {
        public CharacterProjectileCollisionHandler()
        {

        }

        public void HandleCollision(ICharacter character, IProjectile projectile, Types.Direction characterSide, Room room)
        {
            if (projectile.IsFromPlayer() && character is not OldMan && character is not Flame)
            {
                // Boomerangs will bounce off the character and return to the player
                if (projectile is BoomerangProjectile)
                {
                    (projectile as BoomerangProjectile).ReturnBoomerang();
                }

                // The flame/bomb will remain alive until its time is up
                else if (projectile is not FlameProjectile && projectile is not BombProjectile)
                {
                    projectile.DeathAction();
                    ProjectileManager.GetInstance().RemoveProjectile(projectile);
                }

                // The bomb/arrow particle don't damage enemies
                if (projectile is not BombProjectile && projectile is not ArrowExplosionParticle) 
                {
                    new CharacterTakeDamageCommand(character, characterSide, 1, room).Execute();
                }              
            }
        }
    }
}
