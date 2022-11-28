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
            if (CurrentFrame != 0) frame = new Rectangle(frame.X + CurrentFrame * frame.Width, frame.Y, frame.Width, frame.Height);
            return frame;
        }

        public int GetAnimationTime()
        {
            return NumFrames * Speed;
        }

        public Rectangle GetDrawbox(Vector2 position)
        {
            Rectangle frame = GetFirstFrame();

            return new Rectangle((int)(position.X + (xOffsetPixels * GameWindow.ResolutionScale)),
                (int)(position.Y + (yOffsetPixels * GameWindow.ResolutionScale)),
                (int)(frame.Width * GameWindow.ResolutionScale),
                (int)(frame.Height * GameWindow.ResolutionScale));

        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float layer = 0)
        {
            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position), GetCurrentFrame(),
                color, 0, Vector2.Zero, SpriteEffects.None, layer);
        }

        protected void DrawFlippedHorz(SpriteBatch spriteBatch, Vector2 position, Color color, float layer = 0)
        {
            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position), GetCurrentFrame(),
                color, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, layer);
        }

        protected void DrawFlippedVert(SpriteBatch spriteBatch, Vector2 position, Color color, float layer = 0)
        {
            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position), GetCurrentFrame(),
                color, 0, Vector2.Zero, SpriteEffects.FlipVertically, layer);
        }

        protected void DrawFlippedOrigin(SpriteBatch spriteBatch, Vector2 position, Color color, float layer = 0)
        {
            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position), GetCurrentFrame(),
                color, 0, Vector2.Zero, SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally, layer);
        }

        public virtual void Update()
        {
            Timer = (Timer + 1) % Speed;
            if (Timer == 0) CurrentFrame = (CurrentFrame + 1) % NumFrames;
        }
    }
}
