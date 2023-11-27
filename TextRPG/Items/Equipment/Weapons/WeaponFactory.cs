using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Items.Equipment.Weapons
{
    class WeaponFactory
    {
        public static List<Weapon> CreateDefaultWeapon(List<WeaponType> weaponType)
        {
            List < Weapon > items = new List<Weapon>();

            foreach (var type in weaponType)
            {
                switch (type)
                {
                    case WeaponType.Axe:
                        items.Add(new Weapon(
                           ItemGrade.Common,
                           "초보자용 도끼",
                           "낡아보이지만 생각외로 튼튼한 초보자용 도끼이다.",
                           WeaponType.Axe,
                           4, 0, 7, 0, 2, 1, -1, 0, 2, 1, 2, 100
                        ));
                        break;
                    case WeaponType.Sword:
                        items.Add(new Weapon(
                            ItemGrade.Common,
                            "초보자용 미들소드",
                            "무게가 가벼워 검이 익숙하지 않은 사람이어 사용할 수 있다.",
                            WeaponType.Sword,
                            2, 1, 5, 3, 1, 2, 2, 1, 1, 1, 3, 100
                            ));
                        break;
                    case WeaponType.WhiteMageStaff:
                        items.Add(new Weapon(
                            ItemGrade.Common,
                            "초보자용 하얀 지팡이",
                            "오래된 지팡이 초보자가 사용하기엔 안성맞춤이다.",
                            WeaponType.WhiteMageStaff,
                            0, 5, 1, 6, 1, 2, 0, 3, 2, 1, 1, 100
                            ));
                        break;
                    case WeaponType.Knuckle:
                        items.Add(new Weapon(
                           ItemGrade.Common,
                            "초보자용 너클",
                            "근접전을 위한 한쌍의 너클, 가죽으로 만들어졌다.",
                            WeaponType.Knuckle,
                            4, 0, 7, 0, 2, 1, -1, 0, 2, 1, 2, 100
                            ));
                        break;
                    case WeaponType.Spear:
                        items.Add(new Weapon(
                           ItemGrade.Common,
                            "초보자용 창",
                            "공격과 방어의 밸런스가 좋은 장창이다. 생각보다 무겁다.",
                            WeaponType.Spear,
                            4, 0, 7, 0, 2, 1, -1, 0, 2, 1, 2, 100
                            ));
                        break;
                    case WeaponType.Bow:
                        items.Add(new Weapon(
                           ItemGrade.Common,
                            "초보자용 활",
                            "가벼우며 뻑뻑하지 않아 누구나 쉽게 다룰 수 있는 연습용 활이다.",
                            WeaponType.Bow,
                            4, 0, 7, 0, 2, 1, -1, 0, 2, 1, 2, 100
                            ));
                        break;
                    case WeaponType.BlackMageStaff:
                        items.Add(new Weapon(
                           ItemGrade.Common,
                            "초보자용 검은 지팡이",
                            "공격마법에 특화되어 있는 어둠의 지팡이이다. 금방이라도 부셔질 것 같다.",
                            WeaponType.BlackMageStaff,
                            0, 5, 1, 6, 1, 2, 0, 3, 2, 1, 1, 100
                            ));
                        break;
                    default:
                        throw new ArgumentException("잘못된 무기 유형");
                }
            }
            return items;
        }
    }
}
