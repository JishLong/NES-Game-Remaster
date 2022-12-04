using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Assets;

namespace Sprint0.Sprites.Gui
{
    public class SelectedSlotSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().GuiElementsSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().SelectedSlot;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.SelectedSlot;

        protected override bool IsAnimated()
        {
            return true;
        }

        protected override int GetNumFrames()
        {
            return 2;
        }

        protected override int GetAnimationSpeed()
        {
            return 4;
        }
    }
}
