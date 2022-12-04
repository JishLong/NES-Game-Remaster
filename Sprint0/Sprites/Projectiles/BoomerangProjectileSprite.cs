using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Projectiles
{
    public class BoomerangProjectileSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().ProjectilesSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().BoomerangProjectile;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.BoomerangProjectile;

        protected override bool IsAnimated()
        {
            return true;
        }

        protected override int GetNumFrames()
        {
            return 3;
        }

        protected override int GetAnimationSpeed()
        {
            return 6;
        }
    }
}
