using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Blocks
{
    public class BlueGapSprite : AbstractStillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.BlocksSpriteSheet;

        protected override Rectangle GetFrame() => Resources.Water;
    }
}
