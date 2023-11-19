using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Entity.Monsters
{
    public class Goblin : Monster
    {
        public Goblin(int level) : base(MonsterType.Goblin, level)
        {
        }

        protected override void InitStats()
        {
            // 고블린 초기화 로직
            switch (Level)
            {
                case 1:
                    // 고블린 레벨 1 스탯
                    Health = 15;
                    Mana = 8;
                    PhysicalAttack = 4;
                    MagicalAttack = 2;
                    Speed = 3;
                    PhysicalDefense = 2;
                    MagicalDefense = 2;
                    HealingPower = 1;
                    SelfHealingPower = 1;
                    break;
                case 2:
                    // 고블린 레벨 2 스탯
                    Health = 25;
                    Mana = 12;
                    PhysicalAttack = 6;
                    MagicalAttack = 3;
                    Speed = 4;
                    PhysicalDefense = 3;
                    MagicalDefense = 3;
                    HealingPower = 1;
                    SelfHealingPower = 2;
                    break;
                case 3:
                    // 고블린 레벨 3 스탯
                    Health = 35;
                    Mana = 16;
                    PhysicalAttack = 8;
                    MagicalAttack = 4;
                    Speed = 5;
                    PhysicalDefense = 4;
                    MagicalDefense = 4;
                    HealingPower = 2;
                    SelfHealingPower = 2;
                    break;
            }
        }
    }
}
