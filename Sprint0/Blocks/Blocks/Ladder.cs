﻿using Microsoft.Xna.Framework;
using Sprint0.Sprites.Blocks;

namespace Sprint0.Blocks.Blocks
{
    public class Ladder : AbstractBlock
    {
        public Ladder(Vector2 position) : base(new LadderBlockSprite(), position, false) { }
    }
}