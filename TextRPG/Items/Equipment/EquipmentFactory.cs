using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Items.Equipment.Weapons;

namespace TextRPG.Items.Equipment
{
    class EquipmentFactory
    {
        public static Hat CreateCommonHat()
        {
            return new Hat(
                ItemGrade.Common,
                "평범한 모자",
                "기본적인 보호 기능을 제공하는 단순한 모자.",
                price: 20,
                health: 2,
                mana: 1,
                physicalAttack: 0,
                magicalAttack: 0,
                physicalDefense: 1,
                magicalDefense: 1,
                speed: 0,
                healingPower: 0,
                selfHealingPower: 0,
                luck: 1,
                critical: 0,
                durability: 50
           );
        }

        public static Top CreateCommonTop()
        {
            return new Top(
                ItemGrade.Common,
                "평범한 상의",
                "간단한 보호를 위한 기본적인 상의.",
                price: 30,
                health: 3,
                mana: 0,
                physicalAttack: 0,
                magicalAttack: 0,
                physicalDefense: 2,
                magicalDefense: 1,
                speed: 0,
                healingPower: 0,
                selfHealingPower: 0,
                luck: 0,
                critical: 0,
                durability: 60
            );
        }

        public static Gloves CreateCommonGloves()
        {
            return new Gloves(
                ItemGrade.Common,
                "평범한 장갑",
                "손을 보호하기 위한 간단한 장갑.",
                price: 15,
                health: 1,
                mana: 0,
                physicalAttack: 1,
                magicalAttack: 0,
                physicalDefense: 1,
                magicalDefense: 0,
                speed: 1,
                healingPower: 0,
                selfHealingPower: 0,
                luck: 1,
                critical: 1,
                durability: 40
            );
        }

        public static Bottom CreateCommonBottom()
        {
            return new Bottom(
                ItemGrade.Common,
                "평범한 하의",
                "기본적인 보호 기능을 제공하는 단순한 바지.",
                price: 25,
                health: 2,
                mana: 0,
                physicalAttack: 0,
                magicalAttack: 0,
                physicalDefense: 2,
                magicalDefense: 1,
                speed: 1,
                healingPower: 0,
                selfHealingPower: 0,
                luck: 0,
                critical: 0,
                durability: 50
            );
        }

        public static Shoes CreateCommonShoes()
        {
            return new Shoes(
                ItemGrade.Common,
                "평범한 신발",
                "편안한 착용감을 제공하는 기본 신발.",
                price: 20,
                health: 1,
                mana: 0,
                physicalAttack: 0,
                magicalAttack: 0,
                physicalDefense: 1,
                magicalDefense: 0,
                speed: 2,
                healingPower: 0,
                selfHealingPower: 0,
                luck: 1,
                critical: 0,
                durability: 45
            );
        }
    }
}
