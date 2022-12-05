using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class BlueArrowProjectileSprite : AbstractSprite
    {
        private readonly Rectangle DefaultFrame;
        private readonly Types.Direction Direction;

        public BlueArrowProjectileSprite(Types.Direction direction)
        {
            Direction = direction;
            DefaultFrame = direction switch
            {
                Types.Direction.DOWN => AssetManager.DefaultImageAssets.BlueArrowProjectileDown,
                Types.Direction.UP => AssetManager.DefaultImageAssets.BlueArrowProjectileUp,
                Types.Direction.LEFT => AssetManager.DefaultImageAssets.BlueArrowProjectileLeft,
                Types.Direction.RIGHT => AssetManager.DefaultImageAssets.BlueArrowProjectileRight,
                _ => AssetManager.DefaultImageAssets.ArrowProjectileUp,
            };
        }

        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().ProjectilesSpriteSheet;

        protected override Rectangle GetFirstFrame()
        {
            return Direction switch
            {
                Types.Direction.DOWN => ImageMappings.GetInstance().BlueArrowProjectileDown,
                Types.Direction.UP => ImageMappings.GetInstance().BlueArrowProjectileUp,
                Types.Direction.LEFT => ImageMappings.GetInstance().BlueArrowProjectileLeft,
                Types.Direction.RIGHT => ImageMappings.GetInstance().BlueArrowProjectileRight,
                _ => ImageMappings.GetInstance().ArrowProjectileUp,
            };
        }

        protected override Rectangle GetDefaultFrame() => DefaultFrame;
    }
}
