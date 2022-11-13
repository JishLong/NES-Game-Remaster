using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class SnakeRightSprite : AbstractAnimatedSprite
    {
        public SnakeRightSprite() : base(2, 12) { }

        protected override Texture2D GetSpriteSheet() => Resources.CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.Snake;
    }
}
