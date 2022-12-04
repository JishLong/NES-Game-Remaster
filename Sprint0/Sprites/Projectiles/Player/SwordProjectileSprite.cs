using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class SwordProjectileSprite : AbstractSprite
    {
        private readonly Rectangle DefaultFrame;
        private readonly Types.Direction Direction;

        public SwordProjectileSprite(Types.Direction direction)
        {
            Direction = direction;
            DefaultFrame = direction switch
            {
                Types.Direction.DOWN => AssetManager.DefaultImageAssets.SwordProjectileDown,
                Types.Direction.UP => AssetManager.DefaultImageAssets.SwordProjectileUp,
                Types.Direction.LEFT => AssetManager.DefaultImageAssets.SwordProjectileLeft,
                Types.Direction.RIGHT => AssetManager.DefaultImageAssets.SwordProjectileRight,
                _ => AssetManager.DefaultImageAssets.SwordProjectileUp,
            };
        }

        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().ProjectilesSpriteSheet;

        protected override Rectangle GetFirstFrame()
        {
            return Direction switch
            {
                Types.Direction.DOWN => AssetManager.DefaultImageAssets.SwordProjectileDown,
                Types.Direction.UP => AssetManager.DefaultImageAssets.SwordProjectileUp,
                Types.Direction.LEFT => AssetManager.DefaultImageAssets.SwordProjectileLeft,
                Types.Direction.RIGHT => AssetManager.DefaultImageAssets.SwordProjectileRight,
                _ => AssetManager.DefaultImageAssets.SwordProjectileUp,
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
