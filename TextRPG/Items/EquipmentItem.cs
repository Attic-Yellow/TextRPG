using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Items
{
    public enum EquipmentType
    {
        Weapon,
        Hat,
        Top,
        Gloves,
        Bottom,
        Shoes
    }

    public class EquipmentItem : BaseItem
    {
        public EquipmentType EquipmentType { get; set; }
        public int Health { get; set; } // 체력
        public int Mana { get; set; }   // 마나
        public int PhysicalAttack { get; set; } // 힘
        public int MagicalAttack { get; set; }  // 지능
        public int PhysicalDefense { get; set; } // 물리 방어력
        public int MagicalDefense { get; set; } // 마법 방어력
        public int Speed { get; set; } // 민첩성
        public int HealingPower { get; set; } // 정신력
        public int SelfHealingPower { get; set; } // 신앙
        public int Luck { get; set; }   // 행운
        public int Critical { get; set; } // 치명타 확률
        public int Durability { get; set; } // 내구도

        public EquipmentItem(ItemGrade grade, string name, string description, int price, EquipmentType equipmentType, int health, int mana, int physicalAttack, int magicalAttack, int physicalDefense, int magicalDefense, int speed, int healingPower, int selfHealingPower, int luck, int critical, int durability)
            : base(grade, name, description, price)
        {
            EquipmentType = equipmentType;
            Health = health;
            Mana = mana;
            PhysicalAttack = physicalAttack;
            MagicalAttack = magicalAttack;
            PhysicalDefense = physicalDefense;
            MagicalDefense = magicalDefense;
            Speed = speed;
            HealingPower = healingPower;
            SelfHealingPower = selfHealingPower;
            Luck = luck;
            Critical = critical;
            Durability = durability;
        }

        public bool IsBroken => Durability <= 0;

        public void Use()
        {
            if (Durability > 0)
            {
                Durability--;
            }
        }

        public void Repair(int amount)
        {
            Durability += amount;
            // 내구도가 최대치를 초과하지 않도록 조정
        }
    }
}
