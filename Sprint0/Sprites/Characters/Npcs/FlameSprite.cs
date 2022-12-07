using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.Assets;
using Sprint0.GameModes;

namespace Sprint0.Sprites.Characters.Npcs
{
    public class FlameSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().Flame;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.Flame;

        protected override bool IsAnimated()
        {
            return true;
        }

        protected override int GetNumFrames()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MINECRAFTMODE) return 32;
            else return 2;
        }

        protected override int GetAnimationSpeed()
        {
            if (GameModeManager.GetInstance().GameMode.Type == Types.GameMode.MINECRAFTMODE) return 4;
            else return 8;
        }
    }
}
