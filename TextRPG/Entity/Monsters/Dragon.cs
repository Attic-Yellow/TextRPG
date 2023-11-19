using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Entity.Monsters
{
    public class Dragon : Monster
    {
        public Dragon(int level) : base(MonsterType.Dragon, level)
        {
        }

        protected override void InitStats()
        {
            // 드래곤 초기화 로직
            switch (Level)
            {
                case 1:
                    // 드래곤 레벨 1 스탯 (강력한 보스)
                    Health = 50;
                    Mana = 40;
                    PhysicalAttack = 15;
                    MagicalAttack = 15;
                    Speed = 10;
                    PhysicalDefense = 10;
                    MagicalDefense = 10;
                    HealingPower = 5;
                    SelfHealingPower = 5;
                    break;
                case 2:
                    // 드래곤 레벨 2 스탯 (더욱 강력한 보스)
                    Health = 70;
                    Mana = 50;
                    PhysicalAttack = 20;
                    MagicalAttack = 20;
                    Speed = 12;
                    PhysicalDefense = 15;
                    MagicalDefense = 15;
                    HealingPower = 7;
                    SelfHealingPower = 7;
                    break;
                case 3:
                    // 드래곤 레벨 3 스탯 (최강의 보스)
                    Health = 100;
                    Mana = 60;
                    PhysicalAttack = 25;
                    MagicalAttack = 25;
                    Speed = 15;
                    PhysicalDefense = 20;
                    MagicalDefense = 20;
                    HealingPower = 10;
                    SelfHealingPower = 10;
                    break;
            }
        }
    }
}
