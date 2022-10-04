using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Sprites.Npcs
{
    public class FlameSprite : AnimatedSprite
    {
        public FlameSprite() : base(2, 8)
        {

        }

        protected override Texture2D GetSpriteSheet() => Resources.BlocksSpriteSheet;

        protected override Rectangle GetFirstFrame() => Resources.FireBlock;
    }
}
