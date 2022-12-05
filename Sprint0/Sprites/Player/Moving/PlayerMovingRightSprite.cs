using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.GameModes;

namespace Sprint0.Sprites.Player.Moving
{
    public class PlayerMovingRightSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().PlayerSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().PlayerRight;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.PlayerRight;

        protected override bool IsAnimated()
        {
            return true;
        }

        protected override int GetNumFrames()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MARIOMODE) return 4;
            else return 2;
        }

        protected override int GetAnimationSpeed()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MARIOMODE) return 6;
            else return 8;
        }
    }
}
