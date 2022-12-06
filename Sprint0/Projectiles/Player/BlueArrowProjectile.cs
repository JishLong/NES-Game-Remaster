using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Player;
using Sprint0.Projectiles.Tools;
using Sprint0.Collision;
using Sprint0.Assets;

namespace Sprint0.Projectiles.Player
{
    public class BlueArrowProjectile : AbstractProjectile
    {
        private readonly Types.Direction Direction;

        public BlueArrowProjectile(ICollidable user, Types.Direction direction) :
            base(new BlueArrowProjectileSprite(direction), user, direction, 
                new Vector2(15.0f / 3 * GameWindow.ResolutionScale, 15.0f / 3 * GameWindow.ResolutionScale))
        {
            MaxFramesAlive = 40;
            Direction = direction;
            Damage = 4;
            AudioManager.GetInstance().PlayOnce(AudioMappings.GetInstance().ProjectileShoot);
        }

        public override void DeathAction()
        {
            ProjectileManager.GetInstance().AddProjectile(Types.Projectile.ARROW_EXPLOSION_PARTICLE, this, Direction);
        }
    }
}
