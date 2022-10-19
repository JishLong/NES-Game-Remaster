using Microsoft.Xna.Framework;
using Sprint0.Sprites;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class BombExplosionProjectile : AbstractProjectile
    {
        private readonly static Vector2 MovementSpeed = new Vector2(0, 0);

        public BombExplosionProjectile(Vector2 position) :
            base(position, MovementSpeed, Types.Direction.UP)
        {
            Sprite = new BombExplosionProjSprite();
            FramesAlive = ((AnimatedSprite)Sprite).GetAnimationTime() - 1;
        }

        public override bool FromPlayer()
        {
            return true;
        }
    }
}
