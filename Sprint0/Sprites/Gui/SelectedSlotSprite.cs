using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Assets;
using Sprint0.GameModes;

namespace Sprint0.Sprites.Gui
{
    public class SelectedSlotSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().GuiElementsSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().SelectedSlot;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.SelectedSlot;

        protected override bool IsAnimated()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MINECRAFTMODE) return false;
            else return true;
        }

        protected override int GetNumFrames()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MINECRAFTMODE) return 0;
            else return 2;
        }

        protected override int GetAnimationSpeed()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MINECRAFTMODE) return 0;
            else return 4;
        }
    }
}
