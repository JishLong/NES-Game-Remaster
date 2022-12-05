using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Borders
{
    public class BlueBorderSprite: AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().RoomSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().Level1Border;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.Level1Border;
    }
}
