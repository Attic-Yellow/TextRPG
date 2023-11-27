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
        private static List<EquipmentItem> CreateCommonEquipment(List<EquipmentType> equipmentTypes)
        {
            List<EquipmentItem> items = new List<EquipmentItem>();

            foreach (var type in equipmentTypes)
            {
                switch (type)
                {
                    case EquipmentType.Hat:
                        items.Add(new Hat(
                            ItemGrade.Common,
                            "낡은 모자",
                            "낡고 오래된 모자.",
                            4, 0, 7, 0, 2, 1, -1, 0, 2, 1, 2, 100
                        ));
                        items.Add(new Hat(
                            ItemGrade.Uncommon,
                            "가죽 모자",
                            "가죽으로 만들어진 모자.",
                            4, 0, 7, 0, 2, 1, -1, 0, 2, 1, 2, 100
                        ));
                        break;
                    case EquipmentType.Top:
                        items.Add(new Top(
                            ItemGrade.Common,
                            "허름한 셔츠",
                            "사용감이 엄청난 셔츠이다.",
                            4, 0, 7, 0, 2, 1, -1, 0, 2, 1, 2, 100
                        ));
                        break;
                    case EquipmentType.Gloves:
                        items.Add(new Gloves(
                            ItemGrade.Common,
                            "낡은 장갑",
                            "사용감이 엄청난 장갑이다.",
                            4, 0, 7, 0, 2, 1, -1, 0, 2, 1, 2, 100
                        ));
                        break;
                    case EquipmentType.Bottom:
                        items.Add(new Bottom(
                            ItemGrade.Common,
                            "허름한 바지",
                            "사용감이 엄청난 바지이다.",
                            4, 0, 7, 0, 2, 1, -1, 0, 2, 1, 2, 100
                        ));
                        break;
                    case EquipmentType.Shoes:
                        items.Add(new Shoes(
                            ItemGrade.Common,
                            "허름한 신발",
                            "사용감이 엄청난 신발이다.",
                            4, 0, 7, 0, 2, 1, -1, 0, 2, 1, 2, 100
                        ));
                        break;
                    default:
                        throw new ArgumentException("지원하지 않는 장비 유형: " + type.ToString());
                }
            }

            return items;
        }
    }
}
