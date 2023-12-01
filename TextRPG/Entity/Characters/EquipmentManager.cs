using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Items;
using TextRPG.Items.Equipment.Weapons;

namespace TextRPG.Entity.Characters
{
    public class EquipmentManager
    {
        private Dictionary<EquipmentType, EquipmentItem> EquippedItems;

        public EquipmentManager()
        {
            EquippedItems = new Dictionary<EquipmentType, EquipmentItem>();
        }

        public void Equip(Character character, EquipmentItem equipment)
        {
            // 동일 유형의 장비가 이미 착용되어 있는 경우, 그 장비를 먼저 해제
            if (EquippedItems.TryGetValue(equipment.EquipmentType, out EquipmentItem currentEquipment))
            {
                Unequip(character, equipment.EquipmentType);
            }

            EquippedItems[equipment.EquipmentType] = equipment;
            ApplyEquipmentStats(character, equipment, true);
        }

        public void Unequip(Character character, EquipmentType equipmentType)
        {
            if (EquippedItems.TryGetValue(equipmentType, out EquipmentItem equipment))
            {
                ApplyEquipmentStats(character, equipment, false);
                EquippedItems.Remove(equipmentType);
            }
        }

        private static void ApplyEquipmentStats(Character character, EquipmentItem equipment, bool apply)
        {
            // 무기의 능력치를 캐릭터 능력치에 적용하거나 제거
            int modifier = apply ? 1 : -1;

            character.Health += equipment.Health * modifier;
            character.Mana += equipment.Mana * modifier;
            character.PhysicalAttack += equipment.PhysicalAttack * modifier;
            character.MagicalAttack += equipment.MagicalAttack * modifier;
            character.PhysicalDefense += equipment.PhysicalDefense * modifier;
            character.MagicalDefense += equipment.MagicalDefense * modifier;
            character.Speed += equipment.Speed * modifier;
            character.HealingPower += equipment.HealingPower * modifier;
            character.SelfHealingPower += equipment.SelfHealingPower * modifier;
            character.Luck += equipment.Luck * modifier;
            character.Critical += equipment.Critical * modifier;
        }
    }

}
