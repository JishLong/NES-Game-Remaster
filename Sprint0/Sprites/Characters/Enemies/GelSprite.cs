using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Assets;
using Sprint0.GameModes;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class GelSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().Gel;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.Gel;

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
            if (GameModeManager.GetInstance().GameMode.Type != Types.GameMode.DEFAULTMODE) return 12;
            else return 2;
        }
    }
}
