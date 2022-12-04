using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class DodongoRightSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().DodongoRight;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.DodongoRight;

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
            return 16;
        }
    }
}
