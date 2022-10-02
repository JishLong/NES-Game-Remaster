using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Blocks
{
    public abstract class AbstractBlock : IBlock
    {
        // Sprite
        protected ISprite sprite;

        // Coordinates and dimensions
        protected Vector2 Pos;
        protected int W, H;

        protected AbstractBlock (Vector2 pos) 
        {
            Pos = pos;
            W = 64;
            H = 64;
        }

        public void Draw(SpriteBatch sb)
        {
            sprite.Draw(sb, (int)Pos.X, (int)Pos.Y, W, H);
        }

        public void Update()
        {
            // Nothing here?
        }
    }
}
