using Sprint0.Commands.Levels;
using Sprint0.Items;
using Sprint0.Levels;
using Sprint0.Player;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions where the affected object is an item and the acting object is the player
    public class ItemPlayerCollisionHandler
    {
        private Room Room;

        public ItemPlayerCollisionHandler(Room room) 
        {
            Room = room;
        }

        /* NOTE: [itemSide] (aka the side of the item the collision is happening on) isn't actually needed here -
         * at least I think... I'll keep it in the parameters for a while just in case...
         * 
         */
        public void HandleCollision(IItem item, IPlayer player, Types.Direction itemSide) 
        {
            new RemoveItemCommand(Room, item).Execute();

            /* Or for later, some logic like:
             * 
             * if (player.AddToInventory(item) == true)
             * {
             *     room.RemoveItem(item);
             * }
             * 
             */
        }
    }
}
