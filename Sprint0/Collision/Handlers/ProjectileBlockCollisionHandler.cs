using Sprint0.Blocks;
using Sprint0.Blocks.Blocks;
using Sprint0.Levels;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Character_Projectiles;
using Sprint0.Projectiles.Player;
using Sprint0.Projectiles.Player_Projectiles;
using Sprint0.Projectiles.Tools;
using System.Collections.Generic;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between projectiles and blocks
    public class ProjectileBlockCollisionHandler
    {
        private readonly List<System.Type> AffectedProjectiles;

        public ProjectileBlockCollisionHandler()
        {
            AffectedProjectiles = new List<System.Type>{ typeof(BossProjectile), typeof(ArrowProjectile), typeof(BlueArrowProjectile) };
        }

        public void HandleCollision(IProjectile projectile, IBlock block, Types.Direction projectileSide, Room room)
        {
            /* For now, most projectiles are simply destroyed upon hitting a block;
             * Later, projectiles such as link's flame will likely behave differently (such as simply stopping at the wall)
             */
            if ((AffectedProjectiles.Contains(projectile.GetType()) && block.IsWall && block is not SoftBorderBlock)
                || (projectile is SwordProjectile && block is BorderBlock))
            {
                ProjectileManager.GetInstance().RemoveProjectile(projectile);
            }

            // Boomerangs are able to bounce off the dungeon border walls
            else if (projectile is BoomerangProjectile && block is BorderBlock)
            {
                (projectile as BoomerangProjectile).ReturnBoomerang();
            }

            // Flames and bombs will sit at the foot of the block and remain there
            else if ((projectile is FlameProjectile || projectile is BombProjectile) && block.IsWall && block is not SoftBorderBlock)
            {
                projectile.Position = Utils.LineUpEdges(block.GetHitbox(), projectile.GetHitbox(),
                    Utils.GetOppositeDirection(projectileSide));
            }          
        }
    }
}
