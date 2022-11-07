using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Blocks.Blocks
{
    public class RightTransitionTrigger : AbstractBlock
    {
        public RightTransitionTrigger(Vector2 position) : base(new BorderBlockSprite(), position, false) { }
    }
}
