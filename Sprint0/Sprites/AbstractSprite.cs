using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    public abstract class AbstractSprite : ISprite
    {
        protected int CurrentFrame, Timer;

        protected AbstractSprite()
        {
            CurrentFrame = 0;
            Timer = 0;
        }

        protected abstract Texture2D GetSpriteSheet();

        protected abstract Rectangle GetFirstFrame();

        protected abstract Rectangle GetDefaultFrame();

        protected virtual bool IsAnimated()
        {
            return false;
        }

        protected virtual int GetNumFrames() 
        {
            return 0;
        }

        protected virtual int GetAnimationSpeed()
        {
            return 0;
        }

        protected virtual Vector2 GetPixelOffset() 
        {
            return Vector2.Zero;
        }

        private Rectangle GetCurrentFrame()
        {
            Rectangle frame = GetFirstFrame();
            if (IsAnimated() && CurrentFrame != 0) frame = new Rectangle(frame.X + CurrentFrame * frame.Width, frame.Y, frame.Width, frame.Height);
            return frame;
        }

        public int GetAnimationTime()
        {
            return GetNumFrames() * GetAnimationSpeed();
        }

        public Rectangle GetDrawbox(Vector2 position)
        {
            Rectangle frame = GetDefaultFrame();

            return new Rectangle((int)(position.X + (GetPixelOffset().X * GameWindow.ResolutionScale)),
                (int)(position.Y + (GetPixelOffset().Y * GameWindow.ResolutionScale)),
                (int)(frame.Width * GameWindow.ResolutionScale),
                (int)(frame.Height * GameWindow.ResolutionScale));

        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float layer = 0)
        {
            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position), GetCurrentFrame(),
                color, 0, Vector2.Zero, SpriteEffects.None, layer);
        }

        public virtual void DrawFlippedHorizontal(SpriteBatch spriteBatch, Vector2 position, Color color, float layer = 0)
        {
            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position), GetCurrentFrame(),
                color, 0, Vector2.Zero, SpriteEffects.FlipHorizontally, layer);
        }

        public virtual void DrawFlippedVertical(SpriteBatch spriteBatch, Vector2 position, Color color, float layer = 0)
        {
            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position), GetCurrentFrame(),
                color, 0, Vector2.Zero, SpriteEffects.FlipVertically, layer);
        }

        public virtual void DrawFlippedOrigin(SpriteBatch spriteBatch, Vector2 position, Color color, float layer = 0)
        {
            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position), GetCurrentFrame(),
                color, 0, Vector2.Zero, SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically, layer);
        }

        public virtual void Update()
        {
            if (IsAnimated())
            {
                Timer = (Timer + 1) % GetAnimationSpeed();
                if (Timer == 0) CurrentFrame = (CurrentFrame + 1) % GetNumFrames();
            }
        }
    }
}
