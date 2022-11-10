using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    /* This block is essentially an invisible wall;
     * This functionality can be explored in the collision handling system
     */
    public class BorderBlock : AbstractBlock
    {
        public BorderBlock(Vector2 position) : base(new BlueSandSprite(), position, true) { }

        public override void Draw(SpriteBatch sb)
        {
            // This block is invisible, so we simply won't draw anything
        }
    }
}
