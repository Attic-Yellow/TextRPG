using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Entity.Monsters
{
    public class Kobold : Monster
    {
        public Kobold(int level) : base(MonsterType.Kobold, level)
        {
        }

        protected override void InitStats()
        {
            // 코볼트 초기화 로직
            switch (Level)
            {
                case 1:
                    // 코볼트 레벨 1 스탯
                    Health = 20;
                    Mana = 10;
                    PhysicalAttack = 5;
                    MagicalAttack = 3;
                    Speed = 4;
                    PhysicalDefense = 3;
                    MagicalDefense = 2;
                    HealingPower = 1;
                    SelfHealingPower = 1;
                    break;
                case 2:
                    // 코볼트 레벨 2 스탯
                    Health = 30;
                    Mana = 15;
                    PhysicalAttack = 7;
                    MagicalAttack = 4;
                    Speed = 5;
                    PhysicalDefense = 4;
                    MagicalDefense = 3;
                    HealingPower = 1;
                    SelfHealingPower = 2;
                    break;
                case 3:
                    // 코볼트 레벨 3 스탯
                    Health = 40;
                    Mana = 20;
                    PhysicalAttack = 9;
                    MagicalAttack = 5;
                    Speed = 6;
                    PhysicalDefense = 5;
                    MagicalDefense = 4;
                    HealingPower = 2;
                    SelfHealingPower = 3;
                    break;
            }
        }
    }
}
