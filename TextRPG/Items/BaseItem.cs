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

        public BaseItem(ItemGrade grade, string name, string description)
        {
            Grade = grade;
            Name = name;
            Description = description;
        }

        public virtual void Use()
        {
            Console.WriteLine("You used " + Name);
        }

        public virtual void Drop()
        {
            Console.WriteLine("You dropped " + Name);
        }

        public virtual void PickUp()
        {
            Console.WriteLine("You picked up " + Name);
        }
    }
}
