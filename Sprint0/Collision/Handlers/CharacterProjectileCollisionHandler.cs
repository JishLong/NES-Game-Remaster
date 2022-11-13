using Sprint0.Levels;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;
using Sprint0.Projectiles.Player_Projectiles;
using Sprint0.Characters;
using Sprint0.Npcs;
using Sprint0.Characters.Enemies;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between characters and projectiles
    public class CharacterProjectileCollisionHandler
    {
        public void HandleCollision(ICharacter character, IProjectile projectile, Types.Direction characterSide, Room room)
        {
            if (projectile.IsFromPlayer() && projectile is not ArrowExplosionParticle && projectile is not BombProjectile
                && character is not OldMan && character is not Flame)
            {
                // Boomerangs will bounce off the character and return to the player
                if (projectile is BoomerangProjectile) (projectile as BoomerangProjectile).ReturnBoomerang();

                // The flame/bomb will remain alive until its time is up
                else if (projectile is not FlameProjectile && projectile is not BombExplosionParticle)
                {
                    projectile.DeathAction();
                    ProjectileManager.GetInstance().RemoveProjectile(projectile);
                }

                if (projectile is BoomerangProjectile && character is not BladeTrap) 
                {
                    if (character is Bat || character is Gel) character.TakeDamage(characterSide, projectile.Damage, room); 
                    else character.Freeze(false);
                }
                else if (character is not BladeTrap) character.TakeDamage(characterSide, projectile.Damage, room);             
            }
        }
    }
}
