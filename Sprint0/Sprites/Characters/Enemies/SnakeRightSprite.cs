using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Assets;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class SnakeRightSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().Snake;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.Snake;

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
            return 12;
        }
    }
}
