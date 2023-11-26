using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Items.Equipment.Weapons
{
    class WeaponFactory
    {
        public static Weapon CreateDefaultWeapon(WeaponType weaponType)
        {
            switch (weaponType)
            {
                case WeaponType.Axe:
                    return new Weapon(
                        ItemGrade.Common,
                        "초보자용 도끼",
                        "낡아보이지만 생각외로 튼튼한 초보자용 도끼이다.",
                        WeaponType.Axe,
                        health: 4,
                        mana: 0,
                        physicalAttack: 7,
                        magicalAttack: 0,
                        physicalDefense: 2,
                        magicalDefense: 1,
                        speed: -1,
                        healingPower: 0,
                        selfHealingPower: 2,
                        luck: 1,
                        critical: 2,
                        durability: 100
                        );
                case WeaponType.Sword:
                    return new Weapon(
                        ItemGrade.Common,
                        "초보자용 미들소드",
                        "무게가 가벼워 검이 익숙하지 않은 사람이어 사용할 수 있다.",
                        WeaponType.Sword,
                        health: 2,
                        mana: 1,
                        physicalAttack: 5,
                        magicalAttack: 3,
                        physicalDefense: 1,
                        magicalDefense: 2,
                        speed: 2,
                        healingPower: 1,
                        selfHealingPower: 1,
                        luck: 1,
                        critical: 3,
                        durability: 100
                        );
                case WeaponType.WhiteMageStaff:
                    return new Weapon(
                        ItemGrade.Common,
                        "초보자용 하얀 지팡이",
                        "오래된 지팡이 초보자가 사용하기엔 안성맞춤이다.",
                        WeaponType.WhiteMageStaff,
                        health: 0,
                        mana: 5,
                        physicalAttack: 1,
                        magicalAttack: 6,
                        physicalDefense: 1,
                        magicalDefense: 2,
                        speed: 0,
                        healingPower: 3,
                        selfHealingPower: 2,
                        luck: 1,
                        critical: 1,
                        durability: 100
                        );
                case WeaponType.Knuckle:
                    return new Weapon(
                        ItemGrade.Common,
                        "초보자용 너클",
                        "근접전을 위한 한쌍의 너클, 가죽으로 만들어졌다.",
                        WeaponType.Knuckle,
                        health: 2,
                        mana: 1,
                        physicalAttack: 6,
                        magicalAttack: 0,
                        physicalDefense: 1,
                        magicalDefense: 1,
                        speed: 3,
                        healingPower: 1,
                        selfHealingPower: 1,
                        luck: 2,
                        critical: 4,
                        durability: 100
                        );
                case WeaponType.Spear:
                    return new Weapon(
                        ItemGrade.Common,
                        "초보자용 창",
                        "공격과 방어의 밸런스가 좋은 장창이다. 생각보다 무겁다.",
                        WeaponType.Spear,
                        health: 2,
                        mana: 1,
                        physicalAttack: 4,
                        magicalAttack: 3,
                        physicalDefense: 3,
                        magicalDefense: 2,
                        speed: 1,
                        healingPower: 1,
                        selfHealingPower: 1,
                        luck: 1,
                        critical: 2,
                        durability: 100
                        );
                case WeaponType.Bow:
                    return new Weapon(
                        ItemGrade.Common,
                        "초보자용 활",
                        "가벼우며 뻑뻑하지 않아 누구나 쉽게 다룰 수 있는 연습용 활이다.",
                        WeaponType.Bow,
                        health: 4,
                        mana: 2,
                        physicalAttack: 3,
                        magicalAttack: 2,
                        physicalDefense: 1,
                        magicalDefense: 1,
                        speed: 4,
                        healingPower: 1,
                        selfHealingPower: 1,
                        luck: 3,
                        critical: 4,
                        durability: 100
                        );
                case WeaponType.BlackMageStaff:
                    return new Weapon(
                        ItemGrade.Common,
                        "초보자용 검은 지팡이",
                        "공격마법에 특화되어 있는 어둠의 지팡이이다. 금방이라도 부셔질 것 같다.",
                        WeaponType.BlackMageStaff,
                        health: 0,
                        mana: 5,
                        physicalAttack: 1,
                        magicalAttack: 7,
                        physicalDefense: 0,
                        magicalDefense: 1,
                        speed: -2,
                        healingPower: 0,
                        selfHealingPower: 1,
                        luck: 1,
                        critical: 2,
                        durability: 100
                        );
                default:
                    throw new ArgumentException("잘못된 무기 유형");
            }
        }
    }
}
