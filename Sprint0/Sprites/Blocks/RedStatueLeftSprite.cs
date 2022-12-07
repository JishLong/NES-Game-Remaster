using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.GameModes;

namespace Sprint0.Sprites.Blocks
{
    public class RedStatueLeftSprite : AbstractSprite 
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().BlocksSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().RedStatueLeft;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.RedStatueLeft;
        protected override bool IsAnimated()
        {
            return GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MARIOMODE ||
                GameModeManager.GetInstance().GameMode.Type == Types.GameMode.GOOMBAMODE;
        }

        protected override int GetNumFrames()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MARIOMODE ||
                GameModeManager.GetInstance().GameMode.Type == Types.GameMode.GOOMBAMODE) return 4;
            else return 0;
        }

        protected override int GetAnimationSpeed()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MARIOMODE ||
                GameModeManager.GetInstance().GameMode.Type == Types.GameMode.GOOMBAMODE) return 12;
            else return 0;
        }
    }
}
