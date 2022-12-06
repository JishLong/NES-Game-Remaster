using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;
using Sprint0.GameModes;

namespace Sprint0.Sprites.Player.UseItem
{
    public class PlayerUseItemRightSprite : AbstractSprite
    {
        private readonly Vector2 MarioPixelOffset = new(1, 0);
        private readonly Vector2 GoombaPixelOffset = new(-6, 0);

        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().PlayerSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().PlayerSwordRight;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.PlayerSwordRight;
        
        protected override Vector2 GetPixelOffset()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MARIOMODE) return MarioPixelOffset;
            else if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.GOOMBAMODE) return GoombaPixelOffset;
            else return Vector2.Zero;
        }
    }
}
