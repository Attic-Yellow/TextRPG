using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Entity
{
    public class Entity
    {
        protected int level; // 레벨
        protected int health; // 체력
        protected int mana;   // 마나
        protected int physicalAttack; // 힘
        protected int magicalAttack; // 지능
        protected int physicalDefense; // 물리 방어력
        protected int magicalDefense; // 마법 방어력
        protected int speed;  // 민첩성
        protected int healingPower; // 정신력
        protected int selfHealingPower; // 신앙

        public int Level
        {
            get { return level; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("레벨은 음수가 될 수 없습니다.");
                else
                    level = value;
            }
        }
        public int Health
        {
            get { return health; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("체력은 음수가 될 수 없습니다.");
                else
                    health = value;
            }
        }

        public int Mana
        {
            get { return mana; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("마나는 음수가 될 수 없습니다.");
                else
                    mana = value;
            }
        }

        public int PhysicalAttack
        {
            get { return physicalAttack; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("힘은 음수가 될 수 없습니다.");
                else
                    physicalAttack = value;
            }
        }

        public int MagicalAttack
        {
            get { return magicalAttack; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("지능은 음수가 될 수 없습니다.");
                else
                    magicalAttack = value;
            }
        }

        public int PhysicalDefense
        {
            get { return physicalDefense; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("물리 방어력은 음수가 될 수 없습니다.");
                else
                    physicalDefense = value;
            }
        }

        public int MagicalDefense
        {
            get { return magicalDefense; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("마법 방어력은 음수가 될 수 없습니다.");
                else
                    magicalDefense = value;
            }
        }

        public int Speed
        {
            get { return speed; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("민첩성은 음수가 될 수 없습니다.");
                else
                    speed = value;
            }
        }

        public int HealingPower
        {
            get { return healingPower; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("정신력은 음수가 될 수 없습니다.");
                else
                    healingPower = value;
            }
        }

        public int SelfHealingPower
        {
            get { return selfHealingPower; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("신앙은 음수가 될 수 없습니다.");
                else
                    selfHealingPower = value;
            }
        }

        public Entity(int level, int health, int mana, int physicalAttack, int magicalAttack, int physicalDefense, int magicalDefense, int speed,  int healingPower, int selfHealingPower)
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
