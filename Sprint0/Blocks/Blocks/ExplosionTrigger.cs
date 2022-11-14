using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    /* This block is essentially just an invisible trigger for unlocking key locked doors.
     * The implementation of this can be explored in the collision handling system.
     */
    public class ExplosionTrigger : AbstractBlock
    {
        public ExplosionTrigger(Vector2 position) : base(new BlueSandSprite(), position, true) { }

        public override void Draw(SpriteBatch sb)
        {
            // This block is invisible, so we simply won't draw anything
        }
    }
}
