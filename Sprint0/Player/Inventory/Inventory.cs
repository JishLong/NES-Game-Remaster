using System.Collections.Generic;

namespace Sprint0.Player.Inventory
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
            SelectedItem = Types.Item.NOITEM;
            SelectedRow = 0;
            SelectedColumn = 0;
        }

        public void AddToInventory(Types.Item item, int amount)
        {
            // Minimum item count is 0 and maximum item count is 99
            if (amount < 0) return;
            if (ItemCounts.ContainsKey(item)) 
            {
                ItemCounts[item] += amount;
            } 
            else ItemCounts.Add(item, amount);
            if (ItemCounts[item] > 99) ItemCounts[item] = 99;

            if (SelectedItem == Types.Item.NOITEM && GetUsableItems().Length > 0)
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
            // Minimum item count is 0 and maximum item count is 99
            if (amount < 0) return;
            if (ItemCounts.ContainsKey(item))
            {
                ItemCounts[item] -= amount;
                if (ItemCounts[item] < 0) ItemCounts[item] = 0;
            }

            if (ItemCounts[item] == 0 && SelectedItem == item) SelectedItem = Types.Item.NOITEM;
        }

        public int GetAmount(Types.Item item)
        {
            if (ItemCounts.ContainsKey(item)) return ItemCounts[item];
            else return 0;
        }

        public void DecrementItem(Types.Item item)
        {
            if (ItemCounts.ContainsKey(item)) ItemCounts[item]--;
            if (ItemCounts[item] <= 0)
            {
                ItemCounts.Remove(item);
                if (SelectedItem == item) SelectedItem = Types.Item.NOITEM;
            }
        }

        public bool HasItem(Types.Item item)
        {
            return ItemCounts.ContainsKey(item) && ItemCounts[item] > 0;
        }

        private Types.Item[,] GetUsableItems()
        {
            Types.Item[,] UsableItems = new Types.Item[,] { {Types.Item.NOITEM, Types.Item.NOITEM, Types.Item.NOITEM, Types.Item.NOITEM,},
                { Types.Item.NOITEM, Types.Item.NOITEM, Types.Item.NOITEM, Types.Item.NOITEM,} };

            if (HasItem(Types.Item.WOODENBOOMERANG)) UsableItems[0, 0] = Types.Item.WOODENBOOMERANG;
            if (HasItem(Types.Item.BOMB)) UsableItems[0, 1] = Types.Item.BOMB;
            if (HasItem(Types.Item.BOW)) UsableItems[0, 2] = Types.Item.BOW;
            if (HasItem(Types.Item.BLUECANDLE)) UsableItems[0, 3] = Types.Item.BLUECANDLE;
            if (HasItem(Types.Item.BLUEPOTION)) UsableItems[1, 2] = Types.Item.BLUEPOTION;

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
