using Microsoft.Xna.Framework;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class ArrowExplosionParticle : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(0, 0);

        public ArrowExplosionParticle(Vector2 position) :
            base(position, MovementSpeed, Types.Direction.UP)
        {
            Sprite = new ArrowExplosionParticleSprite();
            FramesAlive = 10;         
        }

        public override bool FromPlayer()
        {
            return true;
        }
    }
}
