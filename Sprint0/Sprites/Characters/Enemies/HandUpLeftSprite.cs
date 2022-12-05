using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Assets;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class HandUpLeftSprite : AbstractSprite
    {
        protected override Texture2D GetSpriteSheet() => ImageMappings.GetInstance().CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => ImageMappings.GetInstance().Hand;

        protected override Rectangle GetDefaultFrame() => AssetManager.DefaultImageAssets.Hand;

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
            return 16;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float layer)
        {
            DrawFlippedHorizontal(spriteBatch, position, color, layer);
        }
    }
}
