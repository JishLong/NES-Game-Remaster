using Sprint0.Player;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;
using Sprint0.Projectiles.Character_Projectiles;
using Sprint0.Projectiles.Player_Projectiles;
using Sprint0.Projectiles.Character;
using Sprint0.Assets;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between players and projectiles
    public class PlayerProjectileCollisionHandler
    {
        public void HandleCollision(IPlayer player, IProjectile projectile, Types.Direction playerSide, Game1 game)
        {
            if ((!projectile.IsFromPlayer() || projectile is BombExplosionParticle) 
                && projectile is not DeathParticle && projectile is not SpawnParticle && projectile is not OldManProjectile
                && projectile is not BombProjectile) 
            {
                // NOTE: Link can't block the boss energy balls or bombs
                if (projectile is BladeTrapTrigger) 
                {
                    (projectile as BladeTrapTrigger).TriggerBladeTrap();
                }
                else if (!(player.IsStationary && player.FacingDirection == playerSide) || projectile is BossProjectile || projectile is BombExplosionParticle)
                {
                    player.ChangeHealth(-projectile.Damage, 0, game);
                }    
                else
                {
                    AudioManager.GetInstance().PlayOnce(AudioMappings.GetInstance().ProjectileBlocked);
                }

                // For enemy boomerangs, we want them to bounce off the player and go back to the user
                if (projectile is BoomerangProjectile)
                {
                    (projectile as BoomerangProjectile).ReturnBoomerang();
                }
                else if (projectile is not BombExplosionParticle)
                {
                    projectile.DeathAction();
                    ProjectileManager.GetInstance().RemoveProjectile(projectile);
                }
            }
        }
    }
}
