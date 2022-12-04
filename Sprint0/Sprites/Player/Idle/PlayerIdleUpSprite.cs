using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Player.Idle
{
    public class PlayerIdleUpSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().PlayerSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().PlayerUp;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.PlayerUp;
    }
}
