using Microsoft.Xna.Framework;
using Sprint0.Sprites;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class DeathParticle : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(0, 0);

        public DeathParticle(Vector2 position) :
            base(position, MovementSpeed, Types.Direction.UP, null)
        {
            Sprite = new DeathParticleSprite();
            FramesAlive = ((AbstractAnimatedSprite)Sprite).GetAnimationTime() - 1;
        }
    }
}
