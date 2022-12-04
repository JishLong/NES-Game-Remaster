using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Player.UseItem
{
    public class PlayerUseItemUpSprite : AbstractSprite
    {
        private readonly Vector2 PixelOffset = new(0, -12);

        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().PlayerSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().PlayerSwordUp;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.PlayerSwordUp;

        protected override Vector2 GetPixelOffset()
        {
            return PixelOffset;
        }
    }
}
