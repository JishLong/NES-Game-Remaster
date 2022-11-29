using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.GoombaMode
{
    public class FireballSprite : AbstractAnimatedSprite
    {
        public FireballSprite() : base(4, 8) { }

        protected override Texture2D GetSpriteSheet() => Resources.GoombaMode;

        protected override Rectangle GetFirstFrame() => Resources.Fireball;
    }
}
