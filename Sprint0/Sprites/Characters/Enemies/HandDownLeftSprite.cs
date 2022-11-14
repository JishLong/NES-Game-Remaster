using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class HandDownLeftSprite : AbstractAnimatedSprite
    {
        public HandDownLeftSprite() : base(2, 16) { }

        protected override Texture2D GetSpriteSheet() => Resources.CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.Hand;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float layer)
        {
            DrawFlippedOrigin(spriteBatch, position, color, layer);
        }
    }
}
