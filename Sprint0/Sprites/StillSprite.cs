using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Sprites
{
    public abstract class StillSprite : ISprite
    {
        public StillSprite()
        {
    
        }

        protected abstract Texture2D GetSpriteSheet();

        protected abstract Rectangle GetFrame();

        public void Draw(SpriteBatch spriteBatch, int x, int y, int w, int h)
        {
            Texture2D spriteSheet = GetSpriteSheet();

            spriteBatch.Draw(GetSpriteSheet(), new Rectangle(x, y, w, h), GetFrame(), Color.White);
        }

        public void Update()
        {
            // Nothing here!
        }
    }
}
