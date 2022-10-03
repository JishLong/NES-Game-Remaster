using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Blocks
{
    internal class GreyBricksSprite : ISprite
    {
        public void Draw(SpriteBatch sb, int x, int y, int w, int h)
        {
            Texture2D SpriteSheet = Resources.BlocksSpriteSheet;
            Rectangle SheetPosition = Resources.GreyBricks;

            sb.Draw(SpriteSheet, new Rectangle(x, y, w, h), SheetPosition, Color.White);
        }

        public void Update()
        {
            //Nothing Needed
        }
    }
}
