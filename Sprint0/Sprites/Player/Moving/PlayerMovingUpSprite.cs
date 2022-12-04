using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Player.Moving
{
    public class PlayerMovingUpSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().PlayerSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().PlayerUp;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.PlayerUp;

        protected override bool IsAnimated()
        {
            return true;
        }

        protected override int GetNumFrames()
        {
            return 2;
        }

        protected override int GetAnimationSpeed()
        {
            return 8;
        }
    }
}
