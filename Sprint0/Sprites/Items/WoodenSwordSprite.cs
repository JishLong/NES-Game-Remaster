using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Items
{
    public class WoodenSwordSprite : AbstractStillSprite
    {
        protected override Texture2D GetSpriteSheet() => Resources.WeaponsAndProjSpriteSheet;

        protected override Rectangle GetFrame() => Resources.WoodenSword;
    }
}
