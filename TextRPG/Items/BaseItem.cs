using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Items
{
    public enum ItemGrade
    {
        Common,
        Uncommon,
        Rare,
        Unique
    }

    public class BaseItem
    {
        public ItemGrade Grade { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }  // 가격 속성 추가

        public BaseItem(ItemGrade grade, string name, string description, int price)
        {
            Grade = grade;
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
