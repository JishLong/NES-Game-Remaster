using Microsoft.Xna.Framework;
using Sprint0.Sprites;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class BombExplosionParticle : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(0, 0);

        public BombExplosionParticle(Vector2 position) :
            base(position, MovementSpeed, Types.Direction.UP, null)
        {
            Sprite = new BombExplosionParticleSprite();
            FramesAlive = ((AnimatedSprite)Sprite).GetAnimationTime() - 1;
        }

        public override bool FromPlayer()
        {
            return true;
        }
    }
}
