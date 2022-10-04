using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Sprites.Blocks
{
    public class FireBlockSprite : AnimatedSprite
    {
        public FireBlockSprite() : base(2, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.BlocksSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.FireBlock;
    }
}
