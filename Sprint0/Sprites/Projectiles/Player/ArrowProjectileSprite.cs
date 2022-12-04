using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class ArrowProjectileSprite : AbstractSprite
    {
        private readonly Rectangle DefaultFrame;
        private readonly Types.Direction Direction;

        public ArrowProjectileSprite(Types.Direction direction) 
        {
            Direction = direction;
            DefaultFrame = direction switch
            {
                Types.Direction.DOWN => AssetManager.DefaultImageAssets.ArrowProjectileDown,
                Types.Direction.UP => AssetManager.DefaultImageAssets.ArrowProjectileUp,
                Types.Direction.LEFT => AssetManager.DefaultImageAssets.ArrowProjectileLeft,
                Types.Direction.RIGHT => AssetManager.DefaultImageAssets.ArrowProjectileRight,
                _ => AssetManager.DefaultImageAssets.ArrowProjectileUp,
            };
        }

        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().ProjectilesSpriteSheet;

        protected override Rectangle GetFirstFrame() 
        {
            return Direction switch
            {
                Types.Direction.DOWN => AssetManager.DefaultImageAssets.ArrowProjectileDown,
                Types.Direction.UP => AssetManager.DefaultImageAssets.ArrowProjectileUp,
                Types.Direction.LEFT => AssetManager.DefaultImageAssets.ArrowProjectileLeft,
                Types.Direction.RIGHT => AssetManager.DefaultImageAssets.ArrowProjectileRight,
                _ => AssetManager.DefaultImageAssets.ArrowProjectileUp,
            };
        }

        protected override Rectangle GetDefaultFrame() => DefaultFrame;
    }
}
