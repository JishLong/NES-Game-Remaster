using Sprint0.Commands.Levels;
using Sprint0.Items;
using Sprint0.Levels;
using Sprint0.Player;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between players and items
    public class PlayerItemCollisionHandler
    {
        public void HandleCollision(IPlayer player, IItem item, Types.Direction itemSide, Room room) 
        {
            new RemoveItemCommand(room, item).Execute();

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
