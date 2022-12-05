using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.GameModes;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class SwordFlameProjectileSprite : AbstractSprite
    {
        private readonly Rectangle DefaultFrame;
        private readonly Types.Direction Direction;

        public SwordFlameProjectileSprite(Types.Direction direction)
        {
            Direction = direction;
            DefaultFrame = direction switch
            {
                Types.Direction.UPLEFT => AssetManager.DefaultImageAssets.SwordFlameProjectileUpLeft,
                Types.Direction.UPRIGHT => AssetManager.DefaultImageAssets.SwordFlameProjectileUpRight,
                Types.Direction.DOWNLEFT => AssetManager.DefaultImageAssets.SwordFlameProjectileDownLeft,
                Types.Direction.DOWNRIGHT => AssetManager.DefaultImageAssets.SwordFlameProjectileDownRight,
                _ => AssetManager.DefaultImageAssets.SwordFlameProjectileUpLeft,
            };
        }

        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().ProjectilesSpriteSheet;

        protected override Rectangle GetFirstFrame()
        {
            return Direction switch
            {
                Types.Direction.UPLEFT => ImageMappings.GetInstance().SwordFlameProjectileUpLeft,
                Types.Direction.UPRIGHT => ImageMappings.GetInstance().SwordFlameProjectileUpRight,
                Types.Direction.DOWNLEFT => ImageMappings.GetInstance().SwordFlameProjectileDownLeft,
                Types.Direction.DOWNRIGHT => ImageMappings.GetInstance().SwordFlameProjectileDownRight,
                _ => ImageMappings.GetInstance().SwordFlameProjectileUpLeft,
            };
        }

        protected override Rectangle GetDefaultFrame() => DefaultFrame;

        protected override bool IsAnimated()
        {
            return true;
        }

        protected override int GetNumFrames()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MARIOMODE ||
                GameModeManager.GetInstance().GameMode.Type == Types.GameMode.GOOMBAMODE) return 4;
            else return 2;
        }

        protected override int GetAnimationSpeed()
        {
            return 2;
        }
    }
}
