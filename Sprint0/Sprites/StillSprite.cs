using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Sprites
{
    public abstract class StillSprite : ISprite
    {
        /* [SizeScale]: multiplicative factor for sprite's width and height
         * [xOffset]: multiplicative factor for sprite's x-coordinate
         * [yOffset]: multiplicative factor for sprite's y-coordinate */
        protected float SizeScale, xOffset, yOffset;

        public StillSprite()
        {
            SizeScale = 3;
            xOffset = 0;
            yOffset = 0;
        }

        protected abstract Texture2D GetSpriteSheet();

        protected abstract Rectangle GetFrame();

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Texture2D spriteSheet = GetSpriteSheet();
            Rectangle frame = GetFrame();

            spriteBatch.Draw(GetSpriteSheet(), new Rectangle((int)(position.X + frame.Width * xOffset * SizeScale),
                (int)(position.Y + frame.Height * yOffset * SizeScale),
                (int)(frame.Width * SizeScale), (int)(frame.Height * SizeScale)),
                frame, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle frame = GetFrame();

            spriteBatch.Draw(GetSpriteSheet(), new Rectangle((int)(position.X + frame.Width * xOffset * SizeScale),
                (int)(position.Y + frame.Height * yOffset * SizeScale),
                (int)(frame.Width * SizeScale), (int)(frame.Height * SizeScale)),
                frame, color);
        }

        public void Update()
        {
            // Nothing here!
        }
    }
}
