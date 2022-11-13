using Microsoft.Xna.Framework;
using Sprint0.Blocks;
using Sprint0.Blocks.Blocks;
using Sprint0.Doors;
using Sprint0.Items;
using Sprint0.Levels;
using Sprint0.Levels.Events;

namespace Sprint0.Events
{
    public class EventEnemiesKilledDropsItem : AbstractEvent
    {

        Room CatalystRoom;
        Room OwningRoom;
        IItem Item;
        public EventEnemiesKilledDropsItem(Room catalystRoom, Room owningRoom, IItem item)
        {
            CatalystRoom = catalystRoom;
            OwningRoom = owningRoom;
            Item = item;
        }

        public override void Update(GameTime gameTime)
        {

            if(CatalystRoom.Characters.Count == 0 && Fired == false)
            {
                OwningRoom.AddItemToRoom(Item);
                // Should also play a sound here.
                Fired = true;
            }
        }
    }
}
