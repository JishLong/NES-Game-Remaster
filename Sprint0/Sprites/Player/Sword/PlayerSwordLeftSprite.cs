using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.GameModes;

namespace Sprint0.Sprites.Player.Sword
{
    public class PlayerSwordLeftSprite : AbstractSprite
    {
        private readonly Vector2 DefaultPixelOffset = new(-12, 0);
        private readonly Vector2 GoombaPixelOffset = new(-5, 0);
        private readonly Vector2 MinecraftPixelOffset = new(-11, 0);

        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().PlayerSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().PlayerSwordLeft;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.PlayerSwordLeft;

        protected override bool IsAnimated()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.GOOMBAMODE) return false;
            else return true;
        }

        protected override int GetNumFrames()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.GOOMBAMODE) return 0;
            else return 4;
        }

        protected override int GetAnimationSpeed()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.GOOMBAMODE) return 0;
            else return 4;
        }

        protected override Vector2 GetPixelOffset()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MINECRAFTMODE) return MinecraftPixelOffset;
            else if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.GOOMBAMODE) return GoombaPixelOffset;
            else return DefaultPixelOffset;
        }
    }
}
