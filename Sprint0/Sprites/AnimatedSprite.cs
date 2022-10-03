using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    public abstract class AnimatedSprite : ISprite
    {
        /* [NumFrames] is the number of frames this sprite has
           [Speed] is many game ticks it takes to cycle through one frame */
        private int NumFrames, Speed, CurrentFrame, Timer;

        public AnimatedSprite(int numFrames, int speed)
        {
            NumFrames = numFrames;
            Speed = speed;

            CurrentFrame = 0;
            Timer = 0;
        }

        protected abstract Texture2D GetSpriteSheet();

        protected abstract Rectangle GetFirstFrame();

        public void Draw(SpriteBatch spriteBatch, int x, int y, int w, int h)
        {
            Rectangle frame = GetFirstFrame();
            if (CurrentFrame != 0)
            {
                frame = new Rectangle(CurrentFrame * frame.Width / NumFrames, 0, frame.Width / NumFrames, frame.Height);
            }

            spriteBatch.Draw(GetSpriteSheet(), new Rectangle(x, y, w, h), frame, Color.White);
        }

        public void Update()
        {
            Timer = (Timer + 1) % Speed;
            if (Timer == 0)
            {
                CurrentFrame = (CurrentFrame + 1) % NumFrames;
            }
        }
    }
}
