using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class ArrowExplosionProjectileSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().ProjectilesSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().ArrowExplosionProjectile;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.ArrowExplosionProjectile;
    }
}
