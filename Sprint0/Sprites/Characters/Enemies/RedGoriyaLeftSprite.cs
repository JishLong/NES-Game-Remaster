using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class RedGoriyaLeftSprite : AbstractAnimatedSprite
    {
        public RedGoriyaLeftSprite() : base(2, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.RedGoriyaSide;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            DrawFlippedHorz(spriteBatch, position, color);
        }
    }
}
