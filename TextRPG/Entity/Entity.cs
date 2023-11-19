using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Entity
{
    public class Entity
    {
        public int Level { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int PhysicalAttack { get; set; } // 힘
        public int MagicalAttack { get; set; } // 지능
        public int Speed { get; set; } // 민첩성
        public int PhysicalDefense { get; set; }
        public int MagicalDefense { get; set; }
        public int HealingPower { get; set; } // 정신력
        public int SelfHealingPower { get; set; } // 신앙

        public Entity(int level, int health, int mana, int physicalAttack, int magicalAttack, int speed, int physicalDefense, int magicalDefense, int healingPower, int selfHealingPower)
        {
            Level = level;
            Health = health;
            Mana = mana;
            PhysicalAttack = physicalAttack;
            MagicalAttack = magicalAttack;
            Speed = speed;
            PhysicalDefense = physicalDefense;
            MagicalDefense = magicalDefense;
            HealingPower = healingPower;
            SelfHealingPower = selfHealingPower;
        }
    }
}
