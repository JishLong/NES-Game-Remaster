using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Player.UseItem
{
    public class PlayerUseItemLeftSprite : AbstractSprite
    {
        private readonly Vector2 PixelOffset = new(-12, 0);

        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().PlayerSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().PlayerSwordLeft;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.PlayerSwordLeft;

        protected override Vector2 GetPixelOffset()
        {
            return PixelOffset;
        }
    }
}
