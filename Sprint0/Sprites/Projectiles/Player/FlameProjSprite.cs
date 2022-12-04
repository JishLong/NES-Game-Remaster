using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class FlameProjectileSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().ProjectilesSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().FlameProjectile;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.FlameProjectile;

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
