using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Player.Sword
{
    public class PlayerSwordUpSprite : AbstractSprite
    {
        private readonly Vector2 PixelOffset = new(0, -12);

        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().PlayerSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().PlayerSwordUp;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.PlayerSwordUp;

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
            return PixelOffset;
        }
    }
}
