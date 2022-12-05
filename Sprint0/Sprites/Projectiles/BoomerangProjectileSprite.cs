using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.GameModes;

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
            if (GameModeManager.GetInstance().GameMode.Type != Types.GameMode.DEFAULTMODE) return 4;
            else return 3;
        }

        protected override int GetAnimationSpeed()
        {
            if (GameModeManager.GetInstance().GameMode.Type != Types.GameMode.DEFAULTMODE) return 5;
            else return 6;
        }
    }
}
