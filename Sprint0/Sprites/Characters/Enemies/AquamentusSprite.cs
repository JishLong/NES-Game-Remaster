using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.GameModes;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class AquamentusSprite : AbstractSprite
    { 
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().Aquamentus;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.Aquamentus;

        protected override bool IsAnimated()
        {
            return true;
        }

        protected override int GetNumFrames()
        {
            return 4;
        }

        protected override int GetAnimationSpeed()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.GOOMBAMODE) return 6;
            else return 8;
        }
    }
}
