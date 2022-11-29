using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.GoombaMode.Mario
{
    public class MarioUseItemRightSprite : AbstractStillSprite
    {
        public MarioUseItemRightSprite() : base() { }

        protected override Texture2D GetSpriteSheet() => Resources.GoombaMode;

        protected override Rectangle GetFrame() => Resources.MarioUseItem;
    }
}
