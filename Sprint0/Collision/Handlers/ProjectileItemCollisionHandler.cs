﻿using Sprint0.Blocks.Blocks;
using Sprint0.Blocks;
using Sprint0.Levels;
using Sprint0.Projectiles.Character_Projectiles;
using Sprint0.Projectiles.Player;
using Sprint0.Projectiles.Player_Projectiles;
using Sprint0.Projectiles.Tools;
using Sprint0.Projectiles;
using Sprint0.Items;

namespace Sprint0.Collision.Handlers
{
    public class ProjectileItemCollisionHandler
    {
        public ProjectileItemCollisionHandler()
        {

        }

        public void HandleCollision(IProjectile projectile, IItem item, Types.Direction projectileSide, Room room)
        {
            // The player's boomerang can pick up items - cool trick!
            if (projectile is BoomerangProjectile && projectile.IsFromPlayer()) 
            {
                (projectile as BoomerangProjectile).HoldItem(item);
            }
        }
    }
}