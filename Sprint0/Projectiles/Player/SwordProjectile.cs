using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class SwordProjectile : AbstractProjectile
    {
        public SwordProjectile(ICollidable user, Types.Direction direction) :
            base(new SwordProjSprite(direction), user, direction, new Vector2(8, 8))
        {
            MaxFramesAlive = 1000;
            Damage = 1;
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
