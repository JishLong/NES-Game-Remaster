using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class ArrowExplosionParticle : AbstractProjectile
    {
        public ArrowExplosionParticle(Vector2 position) :
            base(new ArrowExplosionParticleSprite(), null, position, Vector2.Zero, Types.Direction.NO_DIRECTION)
        {
            MaxFramesAlive = 10;         
        }

        public override bool IsFromPlayer()
        {
            return true;
        }
    }
}
