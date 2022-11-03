using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    public abstract class AbstractAnimatedSprite : ISprite
    {
        /* [NumFrames] is the number of frames this sprite has
           [Speed] is many game ticks it takes to cycle through one frame */
        private readonly int NumFrames, Speed;
        protected int CurrentFrame, Timer;

        /* [xOffset]: multiplicative factor for sprite's x-coordinate
         * [yOffset]: multiplicative factor for sprite's y-coordinate */
        protected int xOffsetPixels, yOffsetPixels;

        protected AbstractAnimatedSprite(int numFrames, int speed)
        {
            NumFrames = numFrames;
            Speed = speed;

            CurrentFrame = 0;
            Timer = 0;
            xOffsetPixels = 0;
            yOffsetPixels = 0;
        }

        protected abstract Texture2D GetSpriteSheet();

        protected abstract Rectangle GetFirstFrame();

        private Rectangle GetCurrentFrame() 
        {
            Rectangle frame = GetFirstFrame();
            if (CurrentFrame != 0)
            {
                frame = new Rectangle(frame.X + CurrentFrame * frame.Width, frame.Y, frame.Width, frame.Height);
            }
            return frame;
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Draw(spriteBatch, position, Color.White);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position + Camera.GetOffset()), GetCurrentFrame(),
                color, 0, Vector2.Zero, SpriteEffects.None, 0);
        }

        protected void DrawFlippedHorz(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position + Camera.GetOffset()), GetCurrentFrame(),
                color, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, 0);
        }

        protected void DrawFlippedVert(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position + Camera.GetOffset()), GetCurrentFrame(),
                color, 0, Vector2.Zero, SpriteEffects.FlipVertically, 0);
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

            return new Rectangle((int)(position.X + (xOffsetPixels * Utils.GameScale)),
                (int)(position.Y + (yOffsetPixels * Utils.GameScale)),
                (int)(frame.Width * Utils.GameScale),
                (int)(frame.Height * Utils.GameScale));
        }

        public int GetAnimationTime() 
        {
            return NumFrames * Speed;
        }
    }
}
