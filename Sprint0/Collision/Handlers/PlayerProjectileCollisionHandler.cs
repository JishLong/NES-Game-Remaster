﻿using Sprint0.Commands.Player;
using Sprint0.Levels;
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
        List<System.Type> AffectedProjectiles;

        public PlayerProjectileCollisionHandler()
        {
            AffectedProjectiles = new List<System.Type>{ typeof(BossProjectile), typeof(GoriyaBoomerangProjectile) };
        }

        public void HandleCollision(IPlayer player, IProjectile projectile, Types.Direction playerSide, Room room)
        {
            if (AffectedProjectiles.Contains(projectile.GetType())) 
            {
                // We likely don't want to destroy the boomerangs
                if (!(projectile is GoriyaBoomerangProjectile)) 
                {
                    projectile.DeathAction();
                    ProjectileManager.GetInstance().RemoveProjectile(projectile);
                }               
                if (!(player.IsStationary && player.FacingDirection == playerSide))
                {
                    new PlayerTakeDamageCommand(player, playerSide).Execute();
                }
            }
        }
    }
}