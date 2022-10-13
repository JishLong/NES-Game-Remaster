using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    public abstract class AnimatedSprite : ISprite
    {
        /* [NumFrames] is the number of frames this sprite has
           [Speed] is many game ticks it takes to cycle through one frame */
        protected int NumFrames, Speed, CurrentFrame, Timer;

        /* [SizeScale]: multiplicative factor for sprite's width and height
         * [xOffset]: multiplicative factor for sprite's x-coordinate
         * [yOffset]: multiplicative factor for sprite's y-coordinate */
        protected float SizeScale;
        protected int xOffsetPixels, yOffsetPixels;

        public AnimatedSprite(int numFrames, int speed)
        {
            NumFrames = numFrames;
            Speed = speed;

            CurrentFrame = 0;
            Timer = 0;
            SizeScale = 3;
            xOffsetPixels = 0;
            yOffsetPixels = 0;
        }

        protected abstract Texture2D GetSpriteSheet();

        protected abstract Rectangle GetFirstFrame();

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Draw(spriteBatch, position, Color.White);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle frame = GetFirstFrame();
            if (CurrentFrame != 0)
            {
                frame = new Rectangle(frame.X + CurrentFrame * frame.Width, frame.Y, frame.Width, frame.Height);
            }

            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position), frame, color);
        }

        public virtual void Update()
        {
            Timer = (Timer + 1) % Speed;
            if (Timer == 0)
            {
                CurrentFrame = (CurrentFrame + 1) % NumFrames;
            }
        }

        public Rectangle GetDrawbox(Vector2 position)
        {
            Rectangle frame = GetFirstFrame();

            return new Rectangle((int)(position.X + (xOffsetPixels * SizeScale)), (int)(position.Y + (yOffsetPixels * SizeScale)),
                (int)(frame.Width * SizeScale), (int)(frame.Height * SizeScale));
        }
    }
}
