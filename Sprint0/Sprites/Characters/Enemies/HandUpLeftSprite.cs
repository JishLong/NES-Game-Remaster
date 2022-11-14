using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class HandUpLeftSprite : AbstractAnimatedSprite
    {
        public HandUpLeftSprite() : base(2, 16) { }

        protected override Texture2D GetSpriteSheet() => Resources.CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.Hand;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float layer)
        {
            DrawFlippedHorz(spriteBatch, position, color, layer);
        }
    }
}
