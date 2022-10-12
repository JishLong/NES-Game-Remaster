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
        public abstract void Update();

        public AbstractProjectile(Vector2 position, Vector2 velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        public void Draw(SpriteBatch sb)
        {
            Sprite.Draw(sb, Position);
        }

        public bool TimeIsUp()
        {
            return FramesPassed > FramesAlive;
        }

        public Rectangle GetHitbox() 
        {
            return Sprite.GetDrawbox(Position);
        }
    }
}
