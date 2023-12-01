using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Items
{
    class ConsumableItem : BaseItem
    {
        public int Quantity { get; set; }

        public ConsumableItem(ItemGrade grade, string name, string description, int quantity, int price)
            : base(grade, name, description, price)
        {
            Quantity = quantity;
        }
    }
}
