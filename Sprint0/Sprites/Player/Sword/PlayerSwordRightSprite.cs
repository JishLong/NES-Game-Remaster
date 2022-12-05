using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.Assets.MarioAssets;
using Sprint0.GameModes;

namespace Sprint0.Sprites.Player.Sword
{
    public class PlayerSwordRightSprite : AbstractSprite
    {
        private readonly Vector2 MarioPixelOffset = new(1, 0);

        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().PlayerSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().PlayerSwordRight;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.PlayerSwordRight;

        protected override bool IsAnimated()
        {
            return true;
        }

        protected override int GetNumFrames()
        {
            return 4;
        }

        protected override int GetAnimationSpeed()
        {
            return 4;
        }

        protected override Vector2 GetPixelOffset()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MARIOMODE) return MarioPixelOffset;
            else return Vector2.Zero;
        }
    }
}
