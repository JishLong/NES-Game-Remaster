using Sprint0.Commands.GameStates;
using Sprint0.Commands.Levels;
using Sprint0.Commands.Player;
using Sprint0.Items;
using Sprint0.Items.Items;
using Sprint0.Player;
using System.Collections.Generic;

namespace Sprint0.Collision.Handlers
{
    // Handles all collisions between players and items
    public class PlayerItemCollisionHandler
    {
        private readonly List<System.Type> InventoryItems;

        public PlayerItemCollisionHandler() 
        {
            InventoryItems = new List<System.Type> { typeof(Arrow), typeof(BlueCandle), typeof(BluePotion), typeof(Bomb), typeof(Bow),
            typeof(Compass), typeof(Key), typeof(Map), typeof(Rupee), typeof(WoodenBoomerang) };
        }

        // Inventory and public health manipulation haven't yet been implemented, so for now the item pickup is only cosmetic
        public void HandleCollision(IPlayer player, IItem item, Game1 game)
        {
            if (InventoryItems.Contains(item.GetType()))
            {
                player.Inventory.AddToInventory(item.GetItemType(), 1);
                if (item is Bow) player.PickUpItem(item);

                if (item is Key) AudioManager.GetInstance().PlayOnce(Resources.HeartKeyPickup);
                else if (item is Rupee) AudioManager.GetInstance().PlayOnce(Resources.RupeePickup);
                else AudioManager.GetInstance().PlayOnce(Resources.ItemPickup);               
            }
            else if (item is Clock) 
            {
                // freeze all enemies in the room indefinitely
                AudioManager.GetInstance().PlayOnce(Resources.ItemPickup);
            }
            else if (item is Fairy)
            {
                player.Health += 3;
                if (player.Health > player.MaxHealth) player.Health = player.MaxHealth;
                AudioManager.GetInstance().PlayOnce(Resources.HeartKeyPickup);
            }
            else if (item is Heart)
            {
                player.Health += 1;
                if (player.Health > player.MaxHealth) player.Health = player.MaxHealth;
                AudioManager.GetInstance().PlayOnce(Resources.HeartKeyPickup);
            }
            else if (item is HeartContainer)
            {
                player.MaxHealth += 2;
                player.Health = player.MaxHealth;
                AudioManager.GetInstance().PlayOnce(Resources.ItemPickup);
            }
            else if (item is TriforcePiece)
            {
                new PlayerPickUpItemCommand(player, item).Execute();
                new WinGameCommand(game).Execute();
            }
            new RemoveItemCommand(game.LevelManager.CurrentLevel.CurrentRoom, item).Execute();
        }
    }
}
