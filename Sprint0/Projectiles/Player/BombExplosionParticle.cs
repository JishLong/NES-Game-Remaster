using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class BombExplosionParticle : AbstractProjectile
    {
        public BombExplosionParticle(Vector2 position) :
            base(new BombExplosionParticleSprite(), null, position, Vector2.Zero, Types.Direction.NO_DIRECTION)
        {
            MaxFramesAlive = Sprite.GetAnimationTime() - 1;
        }

        public override bool IsFromPlayer()
        {
            return true;
        }
    }
}
