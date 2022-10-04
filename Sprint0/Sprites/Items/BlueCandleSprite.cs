using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player
{
    public class BlueCandleSprite : StillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.ItemsSpriteSheet;

        protected override Rectangle GetFrame() => Resources.BlueCandle;
    }
}
