using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.GameModes;

namespace Sprint0.Sprites.Player.UseItem
{
    public class PlayerUseItemDownSprite : AbstractSprite
    {
        private readonly Vector2 GoombaPixelOffset = new(0, -6);

        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().PlayerSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().PlayerSwordDown;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.PlayerSwordDown;

        protected override Vector2 GetPixelOffset()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.GOOMBAMODE) return GoombaPixelOffset;
            else return Vector2.Zero;
        }
    }
}
