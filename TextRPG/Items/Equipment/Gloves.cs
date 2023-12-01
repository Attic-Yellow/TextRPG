using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Items.Equipment
{
    class Gloves : EquipmentItem
    {
        public Gloves(ItemGrade grade, string name, string description, int price, int health, int mana, int physicalAttack, int magicalAttack, int physicalDefense, int magicalDefense, int speed, int healingPower, int selfHealingPower, int luck, int critical, int durability)
    : base(grade, name, description, price, EquipmentType.Gloves, health, mana, physicalAttack, magicalAttack, physicalDefense, magicalDefense, speed, healingPower, selfHealingPower, luck, critical, durability)
        {
        }
    }
}
