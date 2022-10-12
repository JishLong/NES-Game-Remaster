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
            /* Here are some potential things that may happen here:
             * 
             * room.RemoveItem(item);
             * 
             * Or perhaps, suppose Player has a method to add an item to their inventory which returns true upon success...
             * 
             * if (player.AddToInventory(item) == true)
             * {
             *     room.RemoveItem(item);
             * }
             *
             * Of course, all that sorta logic should be encapsulated in a command object
             *
             */
        }
    }
}
