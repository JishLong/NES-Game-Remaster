using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class HandDownRightSprite : AbstractAnimatedSprite
    {
        public HandDownRightSprite() : base(2, 16) { }

        protected override Texture2D GetSpriteSheet() => Resources.CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.Hand;

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float layer)
        {
            DrawFlippedVert(spriteBatch, position, color, layer);
        }
    }
}
