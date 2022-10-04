using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Blocks
{
    public class GreyBricksSprite : StillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.BlocksSpriteSheet;

        protected override Rectangle GetFrame() => Resources.GreyBricks;
    }
}
