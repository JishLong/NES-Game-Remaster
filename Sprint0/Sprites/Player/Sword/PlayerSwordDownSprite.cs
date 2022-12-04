using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Player.Sword
{
    public class PlayerSwordDownSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().PlayerSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().PlayerSwordDown;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.PlayerSwordDown;

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
