using Microsoft.Xna.Framework;
using Sprint0.Sprites;
using Sprint0.Sprites.Projectiles.Player;

namespace Sprint0.Projectiles.Player_Projectiles
{
    public class BombProjectile : AbstractProjectile
    {
        private ISprite BombExplosion;
        private int ExplosionTime;

        public BombProjectile(Vector2 position) : base(position, Vector2.Zero)
        {
            FramesAlive = 60;
            FramesPassed = 0;

            Sprite = new BombProjSprite();
            BombExplosion = new BombExplosionProjSprite();
            ExplosionTime = ((AnimatedSprite)BombExplosion).GetAnimationTime();
        }

        public override void Update()
        {
            Sprite.Update();
            FramesPassed++;

            if (FramesPassed == FramesAlive - ExplosionTime + 1)
            {
                Sprite = BombExplosion;
            }
        }

        public override Rectangle GetHitbox()
        {
            Rectangle retVal = (FramesPassed < FramesAlive - ExplosionTime + 1) ? Rectangle.Empty : Sprite.GetDrawbox(Position);
            return retVal;
        }

        public override bool FromPlayer()
        {
            return true;
        }
    }
}
