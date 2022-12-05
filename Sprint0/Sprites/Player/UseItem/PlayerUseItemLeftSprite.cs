using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.GameModes;

namespace Sprint0.Sprites.Player.UseItem
{
    public class PlayerUseItemLeftSprite : AbstractSprite
    {
        private readonly Vector2 DefaultPixelOffset = new(-12, 0);
        private readonly Vector2 MinecraftPixelOffset = new(-11, 0);

        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().PlayerSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().PlayerSwordLeft;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.PlayerSwordLeft;

        protected override Vector2 GetPixelOffset()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MINECRAFTMODE) return MinecraftPixelOffset;
            else if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.GOOMBAMODE) return Vector2.Zero;
            else return DefaultPixelOffset;
        }
    }
}
