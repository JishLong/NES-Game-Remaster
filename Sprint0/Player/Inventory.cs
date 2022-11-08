using System.Collections.Generic;

namespace Sprint0.Player
{
    public class Inventory
    {
        private readonly Dictionary<Types.Item, int> ItemCounts;

        public Inventory() 
        {
            ItemCounts = new Dictionary<Types.Item, int>();
        }

        public void AddToInventory(Types.Item item, int amount)
        {
            if (ItemCounts.ContainsKey(item)) ItemCounts[item] += amount;
            else ItemCounts.Add(item, amount);
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

        public bool HasItem(Types.Item item) 
        {
            return ItemCounts.ContainsKey(item);
        }

        public List<Types.Item> GetUseableItems() 
        {
            List<Types.Item> UseableItems = new();
            if (HasItem(Types.Item.BLUE_CANDLE)) UseableItems.Add(Types.Item.BLUE_CANDLE);
            if (HasItem(Types.Item.BLUE_POTION)) UseableItems.Add(Types.Item.BLUE_POTION);
            if (HasItem(Types.Item.BOMB)) UseableItems.Add(Types.Item.BOMB);
            if (HasItem(Types.Item.BOW)) UseableItems.Add(Types.Item.BOW);
            if (HasItem(Types.Item.WOODEN_BOOMERANG)) UseableItems.Add(Types.Item.WOODEN_BOOMERANG);
            return UseableItems;
        }
    }
}
