using Sprint0.Items;
using System.Collections.Generic;

namespace Sprint0.Player
{
    public class Inventory
    {
        private Dictionary<IItem, int> ItemCounts;

        public Inventory() 
        {
            ItemCounts = new Dictionary<IItem, int>();
        }

        public void AddToInventory(IItem item, int amount)
        {
            if (ItemCounts.ContainsKey(item)) ItemCounts[item] += amount;
            else ItemCounts.Add(item, amount);
        }

        public void RemoveFromInventory(IItem item, int amount) 
        {
            if (ItemCounts.ContainsKey(item)) 
            {
                ItemCounts[item] -= amount;
                if (ItemCounts[item] < 0) ItemCounts[item] = 0;
            }  
        }

        public int GetAmount(IItem item) 
        {
            if (ItemCounts.ContainsKey(item)) return ItemCounts[item];
            else return 0;
        }

        public bool HasItem(IItem item) 
        {
            return ItemCounts.ContainsKey(item);
        }
    }
}
