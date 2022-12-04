using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Projectiles.Player
{
    public class SwordMeleeSprite : AbstractSprite
    {
        private readonly Rectangle DefaultFrame;
        private readonly Types.Direction Direction;

        public SwordMeleeSprite(Types.Direction direction)
        {
            Direction = direction;
            DefaultFrame = direction switch
            {
                Types.Direction.DOWN or Types.Direction.UP => AssetManager.DefaultImageAssets.SwordMeleeVertical,
                Types.Direction.LEFT or Types.Direction.RIGHT => AssetManager.DefaultImageAssets.SwordMeleeHorizontal,
                _ => AssetManager.DefaultImageAssets.SwordMeleeVertical,
            };
        }

        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().ProjectilesSpriteSheet;

        protected override Rectangle GetFirstFrame() 
        {
            return Direction switch
            {
                Types.Direction.DOWN or Types.Direction.UP => AssetManager.DefaultImageAssets.SwordMeleeVertical,
                Types.Direction.LEFT or Types.Direction.RIGHT => AssetManager.DefaultImageAssets.SwordMeleeHorizontal,
                _ => AssetManager.DefaultImageAssets.SwordMeleeVertical,
            };
        }

        protected override Rectangle GetDefaultFrame() => DefaultFrame;
    }
}
