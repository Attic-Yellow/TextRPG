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
        public int Experience { get; set; }
        public CharacterClass JobClass { get; set; }
        public Weapon EquippedWeapon { get; private set; }
        public int Luck { get; internal set; }
        public int Critical { get; internal set; }

        [JsonConstructor]
        public Character(string name, CharacterClass jobClass, int level, int health, int mana, int physicalAttack, int magicalAttack, int physicalDefense, int magicalDefense, int speed, int healingPower, int selfHealingPower, int experience)
           : base(level, health, mana, physicalAttack, magicalAttack, physicalDefense, magicalDefense, speed, healingPower, selfHealingPower)
        {
            Name = name;
            Experience = experience;
            JobClass = jobClass;
            EquipDefaultWeapon(); 
        }

        private void EquipDefaultWeapon()
        {
            switch (JobClass)
            {
                case CharacterClass.Warrior:
                    EquippedWeapon = WeaponFactory.CreateDefaultWeapon(WeaponType.Sword);
                    break;
                case CharacterClass.Knight:
                    EquippedWeapon = WeaponFactory.CreateDefaultWeapon(WeaponType.Sword);
                    break;
                case CharacterClass.WhiteMage:
                    EquippedWeapon = WeaponFactory.CreateDefaultWeapon(WeaponType.WhiteMageStaff);
                    break;
                case CharacterClass.Monk:
                    EquippedWeapon = WeaponFactory.CreateDefaultWeapon(WeaponType.Knuckle);
                    break;
                case CharacterClass.Dragoon:
                    EquippedWeapon = WeaponFactory.CreateDefaultWeapon(WeaponType.Spear);
                    break;  
                case CharacterClass.Bard:
                    EquippedWeapon = WeaponFactory.CreateDefaultWeapon(WeaponType.Bow);
                    break;
                case CharacterClass.BlackMage:
                    EquippedWeapon = WeaponFactory.CreateDefaultWeapon(WeaponType.BlackMageStaff);
                    break;
            }
        }

        public void EquipWeapon(Weapon weapon)
        {
            EquippedWeapon = weapon;
            CharacterStatsManager.ApplyWeaponStats(this, weapon, apply: true);
        }

        public void UnequipWeapon()
        {
            if (EquippedWeapon != null)
            {
                CharacterStatsManager.ApplyWeaponStats(this, EquippedWeapon, apply: false);
                EquippedWeapon = null;
            }
        }

        public EquipmentStats GetTotalEquipmentStats()
        {
            EquipmentStats totalStats = new EquipmentStats();

            if (EquippedWeapon != null)
            {
                totalStats.Health += EquippedWeapon.Health;
                totalStats.Mana += EquippedWeapon.Mana;
                totalStats.PhysicalAttack += EquippedWeapon.PhysicalAttack;
                totalStats.MagicalAttack += EquippedWeapon.MagicalAttack;
                totalStats.PhysicalDefense += EquippedWeapon.PhysicalDefense;
                totalStats.MagicalDefense += EquippedWeapon.MagicalDefense;
                totalStats.Speed += EquippedWeapon.Speed;
                totalStats.HealingPower += EquippedWeapon.HealingPower;
                totalStats.SelfHealingPower += EquippedWeapon.SelfHealingPower;
                totalStats.Luck += EquippedWeapon.Luck;
                totalStats.Critical += EquippedWeapon.Critical;
            }

            // 다른 장비들에 대한 스테이터스 합산 로직...
            // 예: 갑옷, 방패 등

            return totalStats;
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
    public class EquipmentStats
    {
        public int Health { get; set; }
        public int Mana { get; set; }
        public int PhysicalAttack { get; set; }
        public int MagicalAttack { get; set; }
        public int PhysicalDefense { get; set; }
        public int MagicalDefense { get; set; }
        public int Speed { get; set; }
        public int HealingPower { get; set; }
        public int SelfHealingPower { get; set; }
        public int Luck { get; set; }
        public int Critical { get; set; }

    }
}
