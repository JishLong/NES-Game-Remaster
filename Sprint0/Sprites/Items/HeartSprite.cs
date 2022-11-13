using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Sprites.Player
{
    public class HeartSprite : AbstractAnimatedSprite
    {
        public HeartSprite() : base(2, 8) { }

        protected override Texture2D GetSpriteSheet() => Resources.ItemsSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.Heart;
    }
}
