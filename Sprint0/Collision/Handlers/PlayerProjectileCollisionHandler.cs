using Sprint0.Commands.Player;
using Sprint0.Player;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;
using Sprint0.Projectiles.Character;
using Sprint0.Projectiles.Character_Projectiles;
using System.Collections.Generic;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between players and projectiles
    public class PlayerProjectileCollisionHandler
    {
        private readonly List<System.Type> AffectedProjectiles;

        public PlayerProjectileCollisionHandler()
        {
            AffectedProjectiles = new List<System.Type>{ typeof(BossProjectile), typeof(GoriyaBoomerangProjectile) };
        }

        public void HandleCollision(IPlayer player, IProjectile projectile, Types.Direction playerSide)
        {
            if (AffectedProjectiles.Contains(projectile.GetType())) 
            {
                if (!(player.IsStationary && player.FacingDirection == playerSide))
                {
                    new PlayerTakeDamageCommand(player, playerSide, 1).Execute();                
                }
                // For boomerangs, we want them to bounce off the player and go back to the user (in this case, a goriya)
                if (projectile is GoriyaBoomerangProjectile)
                {
                    (projectile as GoriyaBoomerangProjectile).ReturnBoomerang();
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
