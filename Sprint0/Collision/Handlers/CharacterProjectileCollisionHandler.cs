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
        List<System.Type> AffectedProjectiles;

        public CharacterProjectileCollisionHandler()
        {
            AffectedProjectiles = new List<System.Type> { typeof(ArrowProjectile), typeof(BlueArrowProjectile),
            typeof(FlameProjectile), typeof(PlayerBoomerangProjectile), typeof(SwordMelee), typeof(SwordProjectile),
                typeof(SwordFlameProjectile) };
        }

        public void HandleCollision(ICharacter character, IProjectile projectile, Types.Direction characterSide, Room room)
        {
            if (AffectedProjectiles.Contains(projectile.GetType()) && !(character is OldMan) && !(character is Flame))
            {           
                // For boomerangs, we likely want the boomerang to keep going; we don't want it to get used up
                if (!(projectile is PlayerBoomerangProjectile)) 
                {
                    projectile.DeathAction();
                    ProjectileManager.GetInstance().RemoveProjectile(projectile);
                }          
                new CharacterTakeDamageCommand(character, characterSide, 1, room).Execute();
            }
        }
    }
}
