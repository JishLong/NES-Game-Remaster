using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.GoombaMode
{
    public class ToadSprite : AbstractStillSprite
    {
        public ToadSprite() : base() { }

        protected override Texture2D GetSpriteSheet() => Resources.GoombaMode;

        protected override Rectangle GetFrame() => Resources.Toad;
    }
}
