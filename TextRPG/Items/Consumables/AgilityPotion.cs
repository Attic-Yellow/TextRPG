using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Items.Consumables
{
    class AgilityPotion : ConsumableItem
    {
        public int Agility { get; set; }

        public AgilityPotion(ItemGrade grade, string name, string description, int quantity, int price, int agility)
            : base(grade, name, description, quantity, price)
        {
            Agility = agility;
        }
    }
}
