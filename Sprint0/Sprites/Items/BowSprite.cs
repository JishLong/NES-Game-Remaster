using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player
{
    public class BowSprite : ISprite
    {
        public BowSprite()
        {
            
        }

        public void Draw(SpriteBatch sb, int x, int y, int w, int h)
        {
            Texture2D spriteSheet = Resources.StillItemsSpriteSheet;
            Rectangle sheetPosition = Resources.Bow;

            sb.Draw(spriteSheet, new Rectangle(x, y, w, h), sheetPosition, Color.White);
        }

        public void Update()
        {
            // Nothing here!
        }
    }
}
