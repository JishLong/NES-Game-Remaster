using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites
{
    public class MouseCursorSprite : AbstractAnimatedSprite
    {
        public MouseCursorSprite() : base(4, 6) { }

        protected override Texture2D GetSpriteSheet() => Resources.MouseCursor;

        protected override Rectangle GetFirstFrame() => Resources.CursorFrame1;
    }
}
