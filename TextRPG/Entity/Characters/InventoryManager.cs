using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Items;

namespace TextRPG.Entity.Characters
{
    public class InventoryManager
    {
        public List<BaseItem> Items { get; private set; }

        public InventoryManager()
        {
            Items = new List<BaseItem>();
        }

        public void AddItem(BaseItem item)
        {
            var existingItem = Items.OfType<ConsumableItem>().FirstOrDefault(i => i.Name == item.Name);
            if (existingItem != null)
            {
                existingItem.Quantity += ((ConsumableItem)item).Quantity;
            }
            else
            {
                Items.Add(item);
            }
        }

        public void RemoveItem(BaseItem item, int quantity = 1)
        {
            var existingItem = Items.OfType<ConsumableItem>().FirstOrDefault(i => i.Name == item.Name);
            if (existingItem != null)
            {
                existingItem.Quantity -= quantity;
                if (existingItem.Quantity <= 0)
                {
                    Items.Remove(existingItem);
                }
            }
        }
    }
}
