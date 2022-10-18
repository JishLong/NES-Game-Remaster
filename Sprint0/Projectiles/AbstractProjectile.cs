using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using Microsoft.Xna.Framework;

namespace Sprint0.Projectiles
{
    public abstract class AbstractProjectile : IProjectile
    {
        protected ISprite Sprite;

        protected Vector2 Position, Velocity;
        protected int FramesAlive, FramesPassed;

        public AbstractProjectile(Vector2 position, Vector2 velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        public virtual void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }

        public virtual void Update()
        {
            Sprite.Update();
            FramesPassed++;
            Position += Velocity;
        }

        public bool TimeIsUp()
        {
            return FramesPassed > FramesAlive;
        }

        public virtual Rectangle GetHitbox() 
        {
            return Sprite.GetDrawbox(Position);
        }

        public virtual bool FromPlayer()
        {
            return false;
        }
    }
}
