using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Blocks.Blocks;
using Sprint0.Doors;
using Sprint0.Levels.Events;

namespace Sprint0.Events
{
    public class EventPushBlockUnlocksDoor : IEvent
    {

        PushableBlock PBlock;
        Door Door;
        public EventPushBlockUnlocksDoor(IBlock block, Door door)
        {
            PBlock = block as PushableBlock; // Cast to pushable block. 
            Door = door;
        }

        public void Update(GameTime gameTime)
        {
            if (PBlock.HasBeenPushed)
            {
                Door.Unlock();
            }
        }
    }
}
