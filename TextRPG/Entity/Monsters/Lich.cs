using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Entity.Monsters
{
    public class Lich : Monster
    {
        public Lich(int level) : base(MonsterType.Lich, level)
        {
        }

        protected override void InitStats()
        {
            // 리치 초기화 로직
            switch (Level)
            {
                case 1:
                    // 리치 레벨 1 스탯
                    Health = 25;
                    Mana = 30;
                    PhysicalAttack = 3;
                    MagicalAttack = 10;
                    Speed = 3;
                    PhysicalDefense = 3;
                    MagicalDefense = 8;
                    HealingPower = 5;
                    SelfHealingPower = 2;
                    break;
                case 2:
                    // 리치 레벨 2 스탯
                    Health = 35;
                    Mana = 40;
                    PhysicalAttack = 4;
                    MagicalAttack = 15;
                    Speed = 4;
                    PhysicalDefense = 4;
                    MagicalDefense = 12;
                    HealingPower = 7;
                    SelfHealingPower = 3;
                    break;
                case 3:
                    // 리치 레벨 3 스탯
                    Health = 45;
                    Mana = 50;
                    PhysicalAttack = 5;
                    MagicalAttack = 20;
                    Speed = 5;
                    PhysicalDefense = 5;
                    MagicalDefense = 16;
                    HealingPower = 9;
                    SelfHealingPower = 4;
                    break;
            }
        }
    }
}
