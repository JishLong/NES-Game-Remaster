using Sprint0.Blocks;
using Sprint0.Blocks.PushableBlocks;
using Sprint0.Levels;
using Sprint0.Projectiles;
using Sprint0.Projectiles.Character;
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
        List<System.Type> AffectedProjectiles;
        List<System.Type> AffectedBlocks;

        public ProjectileBlockCollisionHandler()
        {
            AffectedProjectiles = new List<System.Type>{ typeof(BossProjectile), typeof(GoriyaBoomerangProjectile),
                typeof(ArrowProjectile), typeof(BlueArrowProjectile), typeof(FlameProjectile), typeof(PlayerBoomerangProjectile) };

            AffectedBlocks = new List<System.Type> { typeof(BlueStatueLeft), typeof(BlueStatueRight),
            typeof(BlueWall), typeof(GreyBricks), typeof(WhiteBars), typeof(PushableBlockUp) };
        }

        /* This type of collision is very simple - certain projectiles get destroyed upon hitting certain blocks;
         * We can just make a list of the projectiles that get destroyed and the blocks that destroy them
         * 
         * Upon hitting a block, a projectile will be forced to prematurely invoke its "death action" (particle effect,
         * spawning more projectiles, etc.) and is then subsequently removed
         */
        public void HandleCollision(IProjectile projectile, IBlock block, Types.Direction itemSide, Room room)
        {
            if (AffectedProjectiles.Contains(projectile.GetType()) && AffectedBlocks.Contains(block.GetType())) 
            {
                projectile.DeathAction();
                ProjectileManager.GetInstance().RemoveProjectile(projectile);
            }
        }
    }
}
