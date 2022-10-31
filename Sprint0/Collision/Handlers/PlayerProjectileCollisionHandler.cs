using Sprint0.Commands.Player;
using Sprint0.Player;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;
using Sprint0.Projectiles.Character_Projectiles;
using System.Collections.Generic;
using Sprint0.Projectiles.Player_Projectiles;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between players and projectiles
    public class PlayerProjectileCollisionHandler
    {
        public PlayerProjectileCollisionHandler()
        {

        }

        public void HandleCollision(IPlayer player, IProjectile projectile, Types.Direction playerSide, Game1 game)
        {
            if (!projectile.IsFromPlayer()) 
            {
                // NOTE: Link can't block the boss energy balls
                if (!(player.IsStationary && player.FacingDirection == playerSide) || projectile is BossProjectile && projectile is not DeathParticle)
                {
                    new PlayerTakeDamageCommand(player, playerSide, 1, game).Execute();
                }    
                else
                {
                    AudioManager.GetInstance().PlayOnce(Resources.ShieldBlock);
                }

                // For enemy boomerangs, we want them to bounce off the player and go back to the user
                if (projectile is BoomerangProjectile)
                {
                    (projectile as BoomerangProjectile).ReturnBoomerang();
                }
                else 
                {
                    projectile.DeathAction();
                    ProjectileManager.GetInstance().RemoveProjectile(projectile);
                }
            }
        }
    }
}
