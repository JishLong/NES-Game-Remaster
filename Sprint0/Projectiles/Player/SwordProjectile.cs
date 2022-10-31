﻿using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class SwordProjectile : AbstractProjectile
    {
        public SwordProjectile(ICollidable user, Types.Direction direction) :
            base(new SwordProjSprite(direction), user, direction, new Vector2(10, 10))
        {
            MaxFramesAlive = 1000;
        }

        public override void DeathAction()
        {
            ProjectileManager PM = ProjectileManager.GetInstance();

            PM.AddProjectile(Types.Projectile.SWORD_FLAME_PROJ, this, Types.Direction.UPLEFT);
            PM.AddProjectile(Types.Projectile.SWORD_FLAME_PROJ, this, Types.Direction.UPRIGHT);
            PM.AddProjectile(Types.Projectile.SWORD_FLAME_PROJ, this, Types.Direction.DOWNLEFT);
            PM.AddProjectile(Types.Projectile.SWORD_FLAME_PROJ, this, Types.Direction.DOWNRIGHT);
        }
    }
}
