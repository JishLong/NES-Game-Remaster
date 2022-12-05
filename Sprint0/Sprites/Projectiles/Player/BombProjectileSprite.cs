using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.GameModes;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class BombProjectileSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().ProjectilesSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().BombProjectile;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.BombProjectile;

        protected override bool IsAnimated()
        {
            return GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MINECRAFTMODE;
        }

        protected override int GetNumFrames()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MINECRAFTMODE) return 2;
            else return 0;
        }

        protected override int GetAnimationSpeed()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MINECRAFTMODE) return 8;
            else return 0;
        }
    }
}
