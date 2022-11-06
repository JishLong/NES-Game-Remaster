using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Projectiles.Player;
using static Sprint0.Utils;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class ArrowProjectile : AbstractProjectile
    {
        private readonly Types.Direction Direction;

        public ArrowProjectile(ICollidable user, Types.Direction direction) :
            base(new ArrowProjSprite(direction), user, direction, new Vector2(15, 15))
        {
            MaxFramesAlive = 20;
            Direction = direction;
            Damage = 2;
            AudioManager.GetInstance().PlayOnce(Resources.ArrowBoomerangShoot);
        }

        public override void DeathAction()
        {
            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.ARROW_EXPLOSION_PARTICLE, this, Direction);
        }
    }
}
