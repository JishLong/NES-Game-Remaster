using Sprint0.Levels;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Tools;
using System.Collections.Generic;
using Sprint0.Projectiles.Player_Projectiles;
using Sprint0.Projectiles.Player;
using Sprint0.Characters;
using Sprint0.Commands.Characters;
using Sprint0.Npcs;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between characters and projectiles
    public class CharacterProjectileCollisionHandler
    {
        private readonly List<System.Type> AffectedProjectiles;

        public CharacterProjectileCollisionHandler()
        {
            AffectedProjectiles = new List<System.Type> { typeof(ArrowProjectile), typeof(BlueArrowProjectile),
            typeof(FlameProjectile), typeof(PlayerBoomerangProjectile), typeof(SwordMelee), typeof(SwordProjectile),
                typeof(SwordFlameProjectile) };
        }

        public void HandleCollision(ICharacter character, IProjectile projectile, Types.Direction characterSide, Room room)
        {
            if (AffectedProjectiles.Contains(projectile.GetType()) && character is not OldMan && character is not Flame)
            {           
                // For boomerangs/flame, we likely don't want it to get used up
                if (projectile is not PlayerBoomerangProjectile && projectile is not FlameProjectile)
                {
                    projectile.DeathAction();
                    ProjectileManager.GetInstance().RemoveProjectile(projectile);
                }
                // For boomerangs, have it bounce off the character
                if (projectile is PlayerBoomerangProjectile) 
                {
                    (projectile as PlayerBoomerangProjectile).ReturnBoomerang();
                }
                // Actual projectile damage values are not yet assigned, for now they will simply take 1 point of damage
                new CharacterTakeDamageCommand(character, characterSide, 1, room).Execute();
            }
        }
    }
}
