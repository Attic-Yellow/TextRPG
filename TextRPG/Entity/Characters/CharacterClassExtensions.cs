using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Items.Equipment.Weapons;

namespace TextRPG.Entity.Characters
{
    public static class CharacterClassExtensions
    {
        public static WeaponType GetWeaponType(this CharacterClass characterClass)
        {
            switch (characterClass)
            {
                case CharacterClass.Warrior:
                    return WeaponType.Axe; // 예: 전사는 도끼 사용
                case CharacterClass.Knight:
                    return WeaponType.Sword; // 예: 나이트는 검 사용
                case CharacterClass.WhiteMage:
                    return WeaponType.WhiteMageStaff;
                case CharacterClass.Monk:
                    return WeaponType.Knuckle;
                case CharacterClass.Dragoon:
                    return WeaponType.Spear;
                case CharacterClass.Bard:
                    return WeaponType.Bow;
                case CharacterClass.BlackMage:
                    return WeaponType.BlackMageStaff;
                default:
                    throw new ArgumentOutOfRangeException(nameof(characterClass), $"Unsupported character class: {characterClass}");
            }
        }
    }
}
