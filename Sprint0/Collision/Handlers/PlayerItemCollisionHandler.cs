using Sprint0.Commands.Levels;
using Sprint0.Items;
using Sprint0.Items.Items;
using Sprint0.Levels;
using Sprint0.Player;
using System.Collections.Generic;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between players and items
    public class PlayerItemCollisionHandler
    {
        private List<System.Type> InventoryItems;

        public PlayerItemCollisionHandler() 
        {
            InventoryItems = new List<System.Type> { typeof(Arrow), typeof(BlueCandle), typeof(BluePotion), typeof(Bomb), typeof(Bow),
            typeof(Clock), typeof(Compass), typeof(Key), typeof(Map), typeof(Rupee), typeof(WoodenBoomerang) };
        }

        public void HandleCollision(IPlayer player, IItem item, Types.Direction itemSide, Room room) 
        {
            if (InventoryItems.Contains(item.GetType()))
            {
                //player.AddToInventory
                new RemoveItemCommand(room, item).Execute();
            }
            else if (item is Heart)
            {
                //player.Health += 1
                new RemoveItemCommand(room, item).Execute();
            }
            else if (item is HeartContainer)
            {
                //player.MaxHealth += 1
                //player.Health = MaxHealth
                new RemoveItemCommand(room, item).Execute();
            }
            else if (item is TriforcePiece) 
            {
                //trigger game winning event
                new RemoveItemCommand(room, item).Execute();
            }
        }
    }
}
