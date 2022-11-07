using Sprint0.Commands.GameStates;
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
        private readonly List<System.Type> InventoryItems;

        public PlayerItemCollisionHandler() 
        {
            InventoryItems = new List<System.Type> { typeof(Arrow), typeof(BlueCandle), typeof(BluePotion), typeof(Bomb), typeof(Bow),
            typeof(Clock), typeof(Compass), typeof(Map), typeof(WoodenBoomerang) };
        }

        // Inventory and public health manipulation haven't yet been implemented, so for now the item pickup is only cosmetic
        public void HandleCollision(IPlayer player, IItem item, Game1 game) 
        {
            if (InventoryItems.Contains(item.GetType()))
            {
                //player.AddToInventory
                AudioManager.GetInstance().PlayOnce(Resources.ItemPickup);
                new RemoveItemCommand(game.LevelManager.CurrentLevel.CurrentRoom, item).Execute();
            }
            else if (item is Heart)
            {
                //player.Health += 1
                AudioManager.GetInstance().PlayOnce(Resources.HeartKeyPickup);
                new RemoveItemCommand(game.LevelManager.CurrentLevel.CurrentRoom, item).Execute();
            }
            else if (item is Fairy)
            {
                //player.Health += 3
                AudioManager.GetInstance().PlayOnce(Resources.HeartKeyPickup);
                new RemoveItemCommand(game.LevelManager.CurrentLevel.CurrentRoom, item).Execute();
            }
            else if (item is Key)
            {
                AudioManager.GetInstance().PlayOnce(Resources.HeartKeyPickup);
                new RemoveItemCommand(game.LevelManager.CurrentLevel.CurrentRoom, item).Execute();
            }
            else if (item is HeartContainer)
            {
                //player.MaxHealth += 1
                //player.Health = MaxHealth
                AudioManager.GetInstance().PlayOnce(Resources.ItemPickup);
                new RemoveItemCommand(game.LevelManager.CurrentLevel.CurrentRoom, item).Execute();
            }
            else if (item is Rupee) 
            {
                AudioManager.GetInstance().PlayOnce(Resources.RupeePickup);
                new RemoveItemCommand(game.LevelManager.CurrentLevel.CurrentRoom, item).Execute();
            }
            else if (item is TriforcePiece)
            {
                new RemoveItemCommand(game.LevelManager.CurrentLevel.CurrentRoom, item).Execute();
                new WinGameCommand(game).Execute();
            }
        }
    }
}
