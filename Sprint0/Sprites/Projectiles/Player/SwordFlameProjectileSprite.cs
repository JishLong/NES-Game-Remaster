using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

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
                Types.Direction.UPLEFT => AssetManager.DefaultImageAssets.SwordFlameProjectileUpLeft,
                Types.Direction.UPRIGHT => AssetManager.DefaultImageAssets.SwordFlameProjectileUpRight,
                Types.Direction.DOWNLEFT => AssetManager.DefaultImageAssets.SwordFlameProjectileDownLeft,
                Types.Direction.DOWNRIGHT => AssetManager.DefaultImageAssets.SwordFlameProjectileDownRight,
                _ => AssetManager.DefaultImageAssets.SwordFlameProjectileUpLeft,
            };
        }

        protected override Rectangle GetDefaultFrame() => DefaultFrame;

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
            return 2;
        }
    }
}
