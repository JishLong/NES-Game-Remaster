using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.GameModes;

namespace Sprint0.Sprites.Blocks
{
    public class BlueStairsSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().BlocksSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().BlueStairs;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.BlueStairs;

        protected override bool IsAnimated()
        {
            return GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MINECRAFTMODE;
        }

        protected override int GetNumFrames()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MINECRAFTMODE) return 32;
            else return 0;
        }

        protected override int GetAnimationSpeed()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MINECRAFTMODE) return 6;
            else return 0;
        }
    }
}
