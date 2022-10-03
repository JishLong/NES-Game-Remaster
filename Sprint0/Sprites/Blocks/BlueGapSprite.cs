using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Blocks
{
    public class BlueGapSprite : StillSprite
    { 
        protected override Rectangle GetFrame()
        {
            return Resources.BlueGap;
        }

        protected override Texture2D GetSpriteSheet()
        {
            return Resources.BlocksSpriteSheet;
        }
    }
}
