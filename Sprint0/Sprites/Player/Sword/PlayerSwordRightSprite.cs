using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Player.Sword
{
    public class PlayerSwordRightSprite : AbstractSprite
    {
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
    }
}
