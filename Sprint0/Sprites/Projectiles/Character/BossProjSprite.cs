using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Projectiles.Character
{
    public class BossProjectileSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().ProjectilesSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().BossProjectile;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.BossProjectile;

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
            return 8;
        }
    }
}
