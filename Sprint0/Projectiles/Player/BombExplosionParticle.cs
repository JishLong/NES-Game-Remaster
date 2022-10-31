using Microsoft.Xna.Framework;
using Sprint0.Collision;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class BombExplosionParticle : AbstractProjectile
    {
        public BombExplosionParticle(ICollidable user) :
            base(new BombExplosionParticleSprite(), user, Types.Direction.NO_DIRECTION, Vector2.Zero)
        {
            MaxFramesAlive = Sprite.GetAnimationTime() - 1;
            Position = Utils.CenterRectangles(user.GetHitbox(), GetHitbox().Width, GetHitbox().Height);
            AudioManager.GetInstance().PlayOnce(Resources.BombExplode);
        }

        public override bool IsFromPlayer()
        {
            return true;
        }
    }
}
