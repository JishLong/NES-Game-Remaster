using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.GoombaMode.Parakoopa
{
    public class ParakoopaLeftSprite : AbstractAnimatedSprite
    {
        public ParakoopaLeftSprite() : base(2, 8) { }

        protected override Texture2D GetSpriteSheet() => Resources.GoombaMode;

        protected override Rectangle GetFirstFrame() => Resources.Parakoopa;
    }
}
