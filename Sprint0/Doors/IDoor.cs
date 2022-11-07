﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using System.Collections.Generic;

namespace Sprint0.Doors
{
    public interface IDoor
    {
        List<IBlock> GetBlocks();
        void Transition();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb);
    }
}