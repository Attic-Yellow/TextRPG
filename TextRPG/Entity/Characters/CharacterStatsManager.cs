using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Items.Equipment.Weapons;

namespace TextRPG.Entity.Characters
{
    public class CharacterStatsManager
    {
        public static void InitClass(Character character)
        {
            switch (character.JobClass)
            {
                case CharacterClass.Warrior:
                    // 전사: 높은 체력, 물리 공격력, 물리 방어력
                    character.Level += 1;
                    character.Health += 20;
                    character.Mana += 5;
                    character.PhysicalAttack += 10;
                    character.PhysicalDefense += 15;
                    character.MagicalAttack += 2;
                    character.MagicalDefense += 5;
                    character.Speed += 5;
                    character.HealingPower += 3;
                    character.SelfHealingPower += 4;
                    break;
                case CharacterClass.Knight:
                    // 나이트: 높은 마나, 마법 방어력
                    character.Level = 1;
                    character.Health += 15;
                    character.Mana += 25;
                    character.PhysicalAttack += 5;
                    character.MagicalAttack += 10;
                    character.MagicalDefense += 15;
                    character.PhysicalDefense += 10;
                    character.Speed += 3;
                    character.HealingPower += 5;
                    character.SelfHealingPower += 3;
                    break;
                case CharacterClass.WhiteMage:
                    // 백마도사: 높은 회복력, 마법 방어력
                    character.Level = 1;
                    character.Health += 10;
                    character.Mana += 15;
                    character.PhysicalAttack += 2;
                    character.MagicalAttack += 10;
                    character.PhysicalDefense += 5;
                    character.MagicalDefense += 15;
                    character.Speed += 3;
                    character.HealingPower += 20;
                    character.SelfHealingPower += 10;
                    break;
                case CharacterClass.Monk:
                    // 수도승: 높은 물리 공격력, 속도
                    character.Level = 1;
                    character.Health += 10;
                    character.Mana += 5;
                    character.PhysicalAttack += 15;
                    character.MagicalAttack += 3;
                    character.PhysicalDefense += 8;
                    character.MagicalDefense += 5;
                    character.Speed += 10;
                    character.HealingPower += 3;
                    character.SelfHealingPower += 4;
                    break;
                case CharacterClass.Dragoon:
                    // 용기사: 균형잡힌 공격력과 방어력
                    character.Level = 1;
                    character.Health += 15;
                    character.Mana += 10;
                    character.PhysicalAttack += 12;
                    character.MagicalAttack += 5;
                    character.PhysicalDefense += 12;
                    character.MagicalDefense += 7;
                    character.Speed += 5;
                    character.HealingPower += 3;
                    character.SelfHealingPower += 5;
                    break;
                case CharacterClass.Bard:
                    // 음유시인: 높은 속도, 중간 물리 공격력
                    character.Level = 1;
                    character.Health += 10;
                    character.Mana += 10;
                    character.PhysicalAttack += 10;
                    character.MagicalAttack += 5;
                    character.PhysicalDefense += 5;
                    character.MagicalDefense += 5;
                    character.Speed += 15;
                    character.HealingPower += 7;
                    character.SelfHealingPower += 3;
                    break;
                case CharacterClass.BlackMage:
                    // 흑마도사: 높은 마법 공격력, 마나
                    character.Level = 1;
                    character.Health += 5;
                    character.Mana += 20;
                    character.PhysicalAttack += 3;
                    character.MagicalAttack += 20;
                    character.PhysicalDefense += 3;
                    character.MagicalDefense += 10;
                    character.Speed += 4;
                    character.HealingPower += 5;
                    character.SelfHealingPower += 3;
                    break;
            }
        }

        public static void LevelUp(Character character)
        {
            character.Level++;

            switch (character.JobClass)
            {
                case CharacterClass.Warrior:
                    // 전사: 체력, 물리 공격력, 물리 방어력 우선 증가
                    character.Health += 10;
                    character.Mana += 2;
                    character.PhysicalAttack += 5;
                    character.MagicalAttack += 1;
                    character.PhysicalDefense += 5;
                    character.MagicalDefense += 2;
                    character.Speed += 2;
                    character.HealingPower += 1;
                    character.SelfHealingPower += 1;
                    character.Experience = 0;
                    break;
                case CharacterClass.Knight:
                    // 나이트: 마나, 마법 방어력, 물리 방어력 우선 증가
                    character.Health += 5;
                    character.Mana += 10;
                    character.PhysicalAttack += 2;
                    character.MagicalAttack += 3;
                    character.PhysicalDefense += 4;
                    character.MagicalDefense += 5;
                    character.Speed += 2;
                    character.HealingPower += 2;
                    character.SelfHealingPower += 1;
                    character.Experience = 0;
                    break;
                case CharacterClass.WhiteMage:
                    // 백마도사(WhiteMage): 타인 회복력과 마법 방어력, 마나 우선 증가
                    character.Health += 4;
                    character.Mana += 5;
                    character.PhysicalAttack += 1;
                    character.MagicalAttack += 3;
                    character.PhysicalDefense += 3;
                    character.MagicalDefense += 5;
                    character.Speed += 2;
                    character.HealingPower += 8;
                    character.SelfHealingPower += 4;
                    character.Experience = 0;
                    break;
                case CharacterClass.Monk:
                    // 수도승(Monk)
                    character.Health += 6;
                    character.Mana += 2;
                    character.PhysicalAttack += 7;
                    character.MagicalAttack += 1;
                    character.PhysicalDefense += 3;
                    character.MagicalDefense += 2;
                    character.Speed += 4;
                    character.HealingPower += 1;
                    character.SelfHealingPower += 1;
                    character.Experience = 0;
                    break;

                case CharacterClass.Dragoon:
                    // 용기사(Dragoon)
                    character.Health += 8;
                    character.Mana += 3;
                    character.PhysicalAttack += 6;
                    character.MagicalAttack += 2;
                    character.PhysicalDefense += 4;
                    character.MagicalDefense += 3;
                    character.Speed += 3;
                    character.HealingPower += 1;
                    character.SelfHealingPower += 1;
                    character.Experience = 0;
                    break;

                case CharacterClass.Bard:
                    // 음유시인(Bard)
                    character.Health += 4;
                    character.Mana += 3;
                    character.PhysicalAttack += 4;
                    character.MagicalAttack += 2;
                    character.PhysicalDefense += 2;
                    character.MagicalDefense += 2;
                    character.Speed += 6;
                    character.HealingPower += 3;
                    character.SelfHealingPower += 2;
                    character.Experience = 0;
                    break;

                case CharacterClass.BlackMage:
                    // 흑마도사(BlackMage)
                    character.Health += 3;
                    character.Mana += 6;
                    character.PhysicalAttack += 1;
                    character.MagicalAttack += 7;
                    character.PhysicalDefense += 2;
                    character.MagicalDefense += 4;
                    character.Speed += 2;
                    character.HealingPower += 2;
                    character.SelfHealingPower += 1;
                    character.Experience = 0;
                    break;
            }
        }
        public static void ApplyWeaponStats(Character character, Weapon weapon, bool apply)
        {
            // 무기의 능력치를 캐릭터 능력치에 적용하거나 제거
            int modifier = apply ? 1 : -1;

            character.Health += weapon.Health * modifier;
            character.Mana += weapon.Mana * modifier;
            character.PhysicalAttack += weapon.PhysicalAttack * modifier;
            character.MagicalAttack += weapon.MagicalAttack * modifier;
            character.PhysicalDefense += weapon.PhysicalDefense * modifier;
            character.MagicalDefense += weapon.MagicalDefense * modifier;
            character.Speed += weapon.Speed * modifier;
            character.HealingPower += weapon.HealingPower * modifier;
            character.SelfHealingPower += weapon.SelfHealingPower * modifier;
            character.Luck += weapon.Luck * modifier;
            character.Critical += weapon.Critical * modifier;
        }
    }
}
