using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class BombExplosionProjectileSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().ProjectilesSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().BombExplosionProjectile;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.BombExplosionProjectile;

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
            return 8;
        }
    }
}
