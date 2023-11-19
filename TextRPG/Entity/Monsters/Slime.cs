using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Entity.Monsters
{
    class Slime : Monster
    {
        public Slime(int level) : base(MonsterType.Slime, level)
        {
        }

        protected override void InitStats()
        {
            // 슬라임 초기화 로직
            switch (Level)
            {
                case 1:
                    Health = 10;
                    Mana = 5;
                    PhysicalAttack = 2;
                    MagicalAttack = 1;
                    Speed = 2;
                    PhysicalDefense = 1;
                    MagicalDefense = 1;
                    HealingPower = 0;
                    SelfHealingPower = 1;
                    break;
                case 2:
                    Health = 20;
                    Mana = 10;
                    PhysicalAttack = 4;
                    MagicalAttack = 2;
                    Speed = 3;
                    PhysicalDefense = 2;
                    MagicalDefense = 2;
                    HealingPower = 0;
                    SelfHealingPower = 2;
                    break;
                case 3:
                    Health = 30;
                    Mana = 15;
                    PhysicalAttack = 6;
                    MagicalAttack = 3;
                    Speed = 4;
                    PhysicalDefense = 3;
                    MagicalDefense = 3;
                    HealingPower = 0;
                    SelfHealingPower = 3;
                    break;
            }
        }
    }
}
