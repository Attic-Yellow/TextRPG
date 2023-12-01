using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TextRPG.Entity.Characters;
using TextRPG.Items.Equipment.Weapons;

namespace TextRPG.Entity
{
    public enum CharacterClass
    {
        // 탱커
        Warrior, // 물리 탱커
        Knight,  // 마법 탱커

        // 힐러
        WhiteMage,  // 힐러

        // 근딜
        Monk,    // 근거리 물리 딜러
        Dragoon, // 근거리 물리 딜러

        // 원딜
        Bard,    // 원거리 물리 딜러

        // 캐스터
        BlackMage // 원거리 마법 딜러
    }

    public class Character : Entity
    {
        public string Name { get; set; }
        public CharacterClass JobClass { get; set; }
        public int Experience { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public int Luck { get; set; }
        public int Critical { get; set; }

        [JsonConstructor]
        public Character(string name, CharacterClass jobClass, int experience, int level, int health, int mana, int physicalAttack, int magicalAttack, int physicalDefense, int magicalDefense, int speed, int healingPower, int selfHealingPower)
           : base(level, health, mana, physicalAttack, magicalAttack, physicalDefense, magicalDefense, speed, healingPower, selfHealingPower)
        {
            Name = name;
            JobClass = jobClass;

        }

        public string GetJobClassNameInKorean()
        {
            switch (JobClass)
            {
                case CharacterClass.Warrior:
                    return "전사";
                case CharacterClass.Knight:
                    return "나이트";
                case CharacterClass.WhiteMage:
                    return "백마도사";
                case CharacterClass.Monk:
                    return "수도승";
                case CharacterClass.Dragoon:
                    return "용기사";
                case CharacterClass.Bard:
                    return "음유시인";
                case CharacterClass.BlackMage:
                    return "흑마도사";
                default:
                    return "알 수 없음";
            }
        }
    }
}
