using Microsoft.Xna.Framework;
using Sprint0.Levels;
using System;
using System.Collections.Generic;

namespace Sprint0.Player
{
    public class Inventory
    {
        private readonly Dictionary<Types.Item, int> ItemCounts;
        public Types.Item SelectedItem { get; set; }
        public int SelectedRow;
        public int SelectedColumn;

        public Inventory() 
        {
            ItemCounts = new Dictionary<Types.Item, int>();
            SelectedItem = Types.Item.NO_ITEM;
            SelectedRow = 0;
            SelectedColumn = 0;
        }

        public void AddToInventory(Types.Item item, int amount)
        {
            if (ItemCounts.ContainsKey(item)) ItemCounts[item] = ItemCounts[item] + amount;
            else ItemCounts.Add(item, amount);

            if (SelectedItem == Types.Item.NO_ITEM && GetUsableItems().Length > 0) 
            {
                SelectedItem = item;
                Types.Item[,] UsableItems = GetUsableItems();
                for (int i = 0; i < UsableItems.GetLength(0); i++)
                    for (int j = 0; j < UsableItems.GetLength(1); j++)
                        if (UsableItems[i, j] == SelectedItem)
                        {
                            SelectedRow = i;
                            SelectedColumn = j;
                            return;
                        }
            }
        }

        public void RemoveFromInventory(Types.Item item, int amount) 
        {
            if (ItemCounts.ContainsKey(item)) 
            {
                ItemCounts[item] -= amount;
                if (ItemCounts[item] < 0) ItemCounts[item] = 0;
            }  
        }

        public int GetAmount(Types.Item item) 
        {
            if (ItemCounts.ContainsKey(item)) return ItemCounts[item];
            else return 0;
        }

        public void DecrementItem(Types.Item item)
        {
            if (ItemCounts.ContainsKey(item)) ItemCounts[item]--;
        }

        public bool HasItem(Types.Item item) 
        {
            return ItemCounts.ContainsKey(item);
        }

        public Types.Item[,] GetUsableItems()
        {
            Types.Item[,] UsableItems = new Types.Item[,] { {Types.Item.NO_ITEM, Types.Item.NO_ITEM, Types.Item.NO_ITEM, Types.Item.NO_ITEM,},
                { Types.Item.NO_ITEM, Types.Item.NO_ITEM, Types.Item.NO_ITEM, Types.Item.NO_ITEM,} };

            if (HasItem(Types.Item.WOODEN_BOOMERANG)) UsableItems[0, 0] = (Types.Item.WOODEN_BOOMERANG);
            if (HasItem(Types.Item.BOMB)) UsableItems[0, 1] = (Types.Item.BOMB);
            if (HasItem(Types.Item.BOW)) UsableItems[0, 2] = (Types.Item.BOW);
            if (HasItem(Types.Item.BLUE_CANDLE)) UsableItems[0, 3] = (Types.Item.BLUE_CANDLE);
            if (HasItem(Types.Item.BLUE_POTION)) UsableItems[1, 2] = (Types.Item.BLUE_POTION);
            
            return UsableItems;
        }

        public void SelectRightItem() 
        {
            Types.Item[,] UsableItems = GetUsableItems();
            SelectedColumn = (SelectedColumn + 1) % UsableItems.GetLength(1);
            SelectedItem = UsableItems[SelectedRow, SelectedColumn];
        }

        public void SelectLeftItem()
        {
            Types.Item[,] UsableItems = GetUsableItems();
            SelectedColumn = (SelectedColumn + UsableItems.GetLength(1) - 1) % UsableItems.GetLength(1);
            SelectedItem = UsableItems[SelectedRow, SelectedColumn];
        }

        public void SelectAboveItem()
        {
            Types.Item[,] UsableItems = GetUsableItems();
            SelectedRow = (SelectedRow + 1) % UsableItems.GetLength(0);
            SelectedItem = UsableItems[SelectedRow, SelectedColumn];
        }

        public void SelectBelowItem()
        {
            Types.Item[,] UsableItems = GetUsableItems();
            SelectedRow = (SelectedRow + 1) % UsableItems.GetLength(0);
            SelectedItem = UsableItems[SelectedRow, SelectedColumn];
        }
    }
}
