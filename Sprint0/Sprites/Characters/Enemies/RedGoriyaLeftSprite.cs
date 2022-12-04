using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class RedGoriyaLeftSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().RedGoriyaLeft;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.RedGoriyaLeft;

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
            return 8;
        }
    }
}
