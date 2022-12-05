using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    /* NOTE: this block is used to trigger a transition into the basement room from the normal dungeon;
     * The implementation of this trigger can be explored in the collision handling system
     */
    public class BlueStairs : AbstractBlock
    {
        public BlueStairs(Vector2 position) : base(new BlueStairsSprite(), position, true) { }
    }
}
