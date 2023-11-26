using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Items.Equipment
{
    class Shoes : EquipmentItem
    {
        public Shoes(ItemGrade grade, string name, string description, int health, int mana, int physicalAttack, int magicalAttack, int physicalDefense, int magicalDefense, int speed, int healingPower, int selfHealingPower, int luck, int critical, int durability)
: base(grade, name, description, EquipmentType.Shoes, health, mana, physicalAttack, magicalAttack, physicalDefense, magicalDefense, speed, healingPower, selfHealingPower, luck, critical, durability)
        {
        }
    }
}
