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

        Room Room;
        IItem Item;
        public EventEnemiesKilledDropsItem(Room room, IItem item)
        {
            Room = room;
            Item = item;
        }

        public override void Update(GameTime gameTime)
        {

            if(Room.Characters.Count == 0 && Fired == false)
            {
                Room.AddItemToRoom(Item);
                Fired = true;
            }
        }
    }
}
