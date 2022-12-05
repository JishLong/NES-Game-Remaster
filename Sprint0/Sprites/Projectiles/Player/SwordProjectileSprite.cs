using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.GameModes;

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
                Types.Direction.DOWN => ImageMappings.GetInstance().SwordProjectileDown,
                Types.Direction.UP => ImageMappings.GetInstance().SwordProjectileUp,
                Types.Direction.LEFT => ImageMappings.GetInstance().SwordProjectileLeft,
                Types.Direction.RIGHT => ImageMappings.GetInstance().SwordProjectileRight,
                _ => ImageMappings.GetInstance().SwordProjectileUp,
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
