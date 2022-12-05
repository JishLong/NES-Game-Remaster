using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.GameModes;

namespace Sprint0.Sprites.Items
{
    public class HeartSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().ItemsSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().Heart;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.Heart;

        protected override bool IsAnimated()
        {
            return GameModeManager.GetInstance().GameMode.Type != Types.GameMode.MINECRAFTMODE;
        }

        protected override int GetNumFrames()
        {
            if (GameModeManager.GetInstance().GameMode.Type != Types.GameMode.MINECRAFTMODE) return 2;
            else return 0;
        }

        protected override int GetAnimationSpeed()
        {
            if (GameModeManager.GetInstance().GameMode.Type != Types.GameMode.MINECRAFTMODE) return 8;
            else return 0;
        }
    }
}
