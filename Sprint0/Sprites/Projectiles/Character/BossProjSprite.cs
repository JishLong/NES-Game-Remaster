using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.GameModes;

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
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MARIOMODE) return 2;
            else return 4;
        }

        protected override int GetAnimationSpeed()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MARIOMODE) return 4;
            else return 8;
        }
    }
}
