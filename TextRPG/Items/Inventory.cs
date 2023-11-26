using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Items.Equipment.Weapons;

namespace TextRPG.Items
{
    public class Inventory
    {
        private List<EquipmentItem> items = new List<EquipmentItem>();

        public void AddItem(EquipmentItem item)
        {
            items.Add(item);
        }

        public EquipmentItem GetItem(int index)
        {
            return items.ElementAtOrDefault(index);
        }

        public bool RemoveItem(EquipmentItem item)
        {
            return items.Remove(item);
        }

        // 필요에 따라 인벤토리 내 특정 유형의 아이템을 찾는 기능 추가 가능
        public IEnumerable<EquipmentItem> GetItemsOfType<T>() where T : EquipmentItem
        {
            return items.OfType<T>();
        }
    }
}
