using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Sprites
{
    public abstract class StillSprite : ISprite
    {
        /* [xOffsetPixels]: a number of pixels the sprite's x-coordinate is offset by (scales with SizeScale)
         * [yOffset]: a number of pixels the sprite's y-coordinate is offset by (scales with SizeScale)
         */
        protected int xOffsetPixels, yOffsetPixels;

        public StillSprite()
        {
            xOffsetPixels = 0;
            yOffsetPixels = 0;
        }

        protected abstract Texture2D GetSpriteSheet();

        protected abstract Rectangle GetFrame();

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Draw(spriteBatch, position, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Draw(spriteBatch, position, color, 0);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float rotation)
        {
            spriteBatch.Draw(GetSpriteSheet(), GetDrawbox(position), GetFrame(), 
                color, rotation, Vector2.Zero, SpriteEffects.None, 0);
        }

        public void Update()
        {
            // Nothing here!
        }

        public Rectangle GetDrawbox(Vector2 position) 
        {
            Rectangle frame = GetFrame();

            return new Rectangle((int)(position.X + (xOffsetPixels * Utils.GameScale)),
                (int)(position.Y + (yOffsetPixels * Utils.GameScale)),
                (int)(frame.Width * Utils.GameScale), 
                (int)(frame.Height * Utils.GameScale));
        }
    }
}
