using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.GoombaMode.Goomba
{
    public class GoombaIdleSprite : AbstractStillSprite
    {
        public GoombaIdleSprite() : base() { }

        protected override Texture2D GetSpriteSheet() => Resources.GoombaMode;

        protected override Rectangle GetFrame() => Resources.Goomba;
    }
}
