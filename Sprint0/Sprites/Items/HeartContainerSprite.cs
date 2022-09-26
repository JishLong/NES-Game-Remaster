using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player
{
    public class HeartContainerSprite : ISprite
    {
        // Texture
        private Texture2D spriteSheet;
        private Rectangle sheetPosition;

        public HeartContainerSprite()
        {
            spriteSheet = Resources.stillItemsSheet;
            sheetPosition = Resources.heartContainer;
        }

        public void Draw(SpriteBatch sb, int x, int y, int w, int h)
        {
            sb.Draw(spriteSheet, new Rectangle(x, y, w, h), sheetPosition, Color.White);
        }

        public void Update()
        {
            // Nothing here!
        }
    }
}

