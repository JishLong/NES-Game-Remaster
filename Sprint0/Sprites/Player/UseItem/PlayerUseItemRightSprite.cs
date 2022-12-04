using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Player.UseItem
{
    public class PlayerUseItemRightSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().PlayerSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().PlayerSwordRight;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.PlayerSwordRight;
    }
}
