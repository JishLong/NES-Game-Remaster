using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.GoombaMode.Mario
{
    public class MarioMovingRightSprite : AbstractAnimatedSprite
    {
        public MarioMovingRightSprite() : base(2, 8) { }

        protected override Texture2D GetSpriteSheet() => Resources.GoombaMode;

        protected override Rectangle GetFirstFrame() => Resources.Mario;
    }
}
