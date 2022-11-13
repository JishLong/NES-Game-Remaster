using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Characters.Enemies
{
    public class RedGoriyaDownSprite : AbstractAnimatedSprite
    {
        public RedGoriyaDownSprite() : base(2, 8) { }

        protected override Texture2D GetSpriteSheet() => Resources.CharactersSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.RedGoriyaDown;
    }
}
