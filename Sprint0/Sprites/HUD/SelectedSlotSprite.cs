using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Sprites.HUD
{
    public class SelectedSlotSprite : AbstractAnimatedSprite
    {
        public SelectedSlotSprite() : base(2, 4) { }

        protected override Texture2D GetSpriteSheet() => Resources.GuiElementsSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.SelectedSlot;
    }
}
