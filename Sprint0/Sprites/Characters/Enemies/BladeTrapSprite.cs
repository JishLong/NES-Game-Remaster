using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class BladeTrapSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().BladeTrap;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.BladeTrap;
    }
}
