using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.GameModes;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class DodongoUpSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().DodongoUp;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.DodongoUp;

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
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.GOOMBAMODE) return 12;
            else return 16;
        }
    }
}
