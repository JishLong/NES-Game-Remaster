using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Items
{
    public class TriforcePieceSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().ItemsSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().TriforcePiece;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.TriforcePiece;

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
