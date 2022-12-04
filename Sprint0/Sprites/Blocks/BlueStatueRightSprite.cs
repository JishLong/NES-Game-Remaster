using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Blocks
{
    public class BlueStatueRightSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().BlocksSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().BlueStatueRight;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.BlueStatueRight;
    }
}
