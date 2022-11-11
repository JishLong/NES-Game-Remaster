using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Blocks;
using System.Collections.Generic;

namespace Sprint0.Doors.States
{
    public interface IDoorState
    {
        List<IBlock> GetBlocks();
        Types.RoomTransition GetTransitionDirection();
        void Lock();
        void Unlock();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch sb);
    }
}
