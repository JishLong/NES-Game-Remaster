using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Player;
using Sprint0.Projectiles.Tools;
using Sprint0.Sprites.Projectiles.Player;
using static Sprint0.Types;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class BombExplosionParticle : AbstractProjectile
    {
        public BombExplosionParticle(ICollidable user, Types.Direction direction) :
            base(new BombExplosionParticleSprite(), user, direction, Vector2.Zero)
        {
            MaxFramesAlive = Sprite.GetAnimationTime() - 1;        
            Damage = 4;
            if (user is BombProjectile)
            {
                Position = Utils.CenterRectangles(user.GetHitbox(), GetHitbox().Width, GetHitbox().Height);
                AudioManager.GetInstance().PlayOnce(Resources.BombExplode);
                ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOMB_EXPLOSION_PARTICLE, this, Direction.LEFT);
                ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOMB_EXPLOSION_PARTICLE, this, Direction.RIGHT);
                ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOMB_EXPLOSION_PARTICLE, this, Direction.UP);
                ProjectileManager.GetInstance().AddProjectile(Types.Projectile.BOMB_EXPLOSION_PARTICLE, this, Direction.DOWN);
            }     
        }

        public override bool IsFromPlayer()
        {
            return true;
        }
    }
}
