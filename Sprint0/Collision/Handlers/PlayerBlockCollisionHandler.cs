using Sprint0.Commands.Levels;
using Sprint0.Items;
using Sprint0.Levels;
using Sprint0.Player;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions where the affected object is an item and the acting object is the player
    public class PlayerBlockCollisionHandler
    {
        private Room Room;

        public PlayerBlockCollisionHandler(Room room) 
        {
            Room = room;
        }

        /* NOTE: [itemSide] (aka the side of the item the collision is happening on) isn't actually needed here -
         * at least I think... I'll keep it in the parameters for a while just in case...
         * 
         * itemSide is the effected side of the reciever and impacting colider would be the opposite side
         * would want to set the players X value 
         * 
         * both block and player
         * 
         * block: if pushable -> block.push
         * 
         * player not running into block: switch case for hitting top,bottom,left and right of block and reset x and y values accordingly 
         * 
         */
        public void HandleCollision(IPlayer player, IItem item, Types.Direction itemSide) 
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
