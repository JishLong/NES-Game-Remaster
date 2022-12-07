using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.GameModes;

namespace Sprint0.Sprites.Player.UseItem
{
    public class PlayerUseItemUpSprite : AbstractSprite
    {
        private readonly Vector2 PixelOffset = new(0, -12);
        private readonly Vector2 GoombaPixelOffset = new(0, -5);

        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().PlayerSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().PlayerSwordUp;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.PlayerSwordUp;

        protected override Vector2 GetPixelOffset()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.GOOMBAMODE) return GoombaPixelOffset;
            else return PixelOffset;
        }
    }
}
