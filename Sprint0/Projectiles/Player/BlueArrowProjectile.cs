using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Player;
using Sprint0.Projectiles.Tools;
using Sprint0.Collision;

namespace Sprint0.Projectiles.Player
{
    public class BlueArrowProjectile : AbstractProjectile
    {
        private readonly Types.Direction Direction;

        public BlueArrowProjectile(ICollidable user, Types.Direction direction) :
            base(new BlueArrowProjSprite(direction), user, direction, new Vector2(15, 15))
        {
            MaxFramesAlive = 40;
            Direction = direction;
            Damage = 4;
            AudioManager.GetInstance().PlayOnce(Resources.ArrowBoomerangShoot);
        }

        public override void DeathAction()
        {
            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.ARROW_EXPLOSION_PARTICLE, this, Direction);
        }
    }
}
