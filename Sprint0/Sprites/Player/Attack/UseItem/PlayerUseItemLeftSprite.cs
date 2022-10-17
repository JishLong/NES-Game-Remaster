using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Player.Attack.UseItem
{
    public class PlayerUseItemLeftSprite : StillSprite
    {
        public PlayerUseItemLeftSprite()
        {
            xOffsetPixels = -12;
        }

        protected override Texture2D GetSpriteSheet() => Resources.LinkSpriteSheet;

        protected override Rectangle GetFrame() => Resources.LinkSwordLeft;
    }
}
