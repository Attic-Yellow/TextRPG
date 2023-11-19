using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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

    class Character : Entity
    {
        public string Name { get; set; }
        public CharacterClass JobClass { get; set; }
        public int Experience { get; private set; }

        public Character(string name, CharacterClass characterClass, int level, int health, int mana, int physicalAttack, int magicalAttack, int speed, int physicalDefense, int magicalDefense, int healingPower, int selfHealingPower)
            : base(level, health, mana, physicalAttack, magicalAttack, speed, physicalDefense, magicalDefense, healingPower, selfHealingPower)
        {
            Name = name;
            JobClass = characterClass;
            InitClass(); // 직업별 추가 능력치 설정
        }

        private void InitClass()
        {
            switch (JobClass)
            {
                case CharacterClass.Warrior:
                    // 전사: 높은 체력, 물리 공격력, 물리 방어력
                    Health += 20;
                    PhysicalAttack += 10;
                    PhysicalDefense += 15;
                    Speed += 5;
                    Mana += 5;
                    MagicalAttack += 2;
                    MagicalDefense += 5;
                    HealingPower += 3;
                    SelfHealingPower += 4;
                    break;
                case CharacterClass.Knight:
                    // 나이트: 높은 마나, 마법 방어력
                    Mana += 25;
                    MagicalDefense += 15;
                    Health += 15;
                    PhysicalAttack += 5;
                    MagicalAttack += 10;
                    Speed += 3;
                    PhysicalDefense += 10;
                    HealingPower += 5;
                    SelfHealingPower += 3;
                    break;
                case CharacterClass.WhiteMage:
                    // 백마도사: 높은 타인 회복력, 마법 방어력
                    HealingPower += 20;
                    MagicalDefense += 15;
                    Health += 10;
                    Mana += 15;
                    PhysicalAttack += 2;
                    MagicalAttack += 10;
                    Speed += 3;
                    PhysicalDefense += 5;
                    SelfHealingPower += 10;
                    break;
                case CharacterClass.Monk:
                    // 수도승: 높은 물리 공격력, 속도
                    PhysicalAttack += 15;
                    Speed += 10;
                    Health += 10;
                    Mana += 5;
                    MagicalAttack += 3;
                    PhysicalDefense += 8;
                    MagicalDefense += 5;
                    HealingPower += 3;
                    SelfHealingPower += 4;
                    break;
                case CharacterClass.Dragoon:
                    // 용기사: 균형잡힌 공격력과 방어력
                    PhysicalAttack += 12;
                    PhysicalDefense += 12;
                    Health += 15;
                    Mana += 10;
                    Speed += 5;
                    MagicalAttack += 5;
                    MagicalDefense += 7;
                    HealingPower += 3;
                    SelfHealingPower += 5;
                    break;
                case CharacterClass.Bard:
                    // 음유시인: 높은 속도, 중간 물리 공격력
                    Speed += 15;
                    PhysicalAttack += 10;
                    Health += 10;
                    Mana += 10;
                    MagicalAttack += 5;
                    PhysicalDefense += 5;
                    MagicalDefense += 5;
                    HealingPower += 7;
                    SelfHealingPower += 3;
                    break;
                case CharacterClass.BlackMage:
                    // 흑마도사: 높은 마법 공격력, 마나
                    MagicalAttack += 20;
                    Mana += 20;
                    Health += 5;
                    PhysicalAttack += 3;
                    Speed += 4;
                    PhysicalDefense += 3;
                    MagicalDefense += 10;
                    HealingPower += 5;
                    SelfHealingPower += 3;
                    break;
            }
        }

        public void LevelUp()
        {
            Level++;

            switch (JobClass)
            {
                case CharacterClass.Warrior:
                    // 전사: 체력, 물리 공격력, 물리 방어력 우선 증가
                    Health += 10;
                    Mana += 2;
                    PhysicalAttack += 5;
                    MagicalAttack += 1;
                    PhysicalDefense += 5;
                    MagicalDefense += 2;
                    Speed += 2;
                    HealingPower += 1;
                    SelfHealingPower += 1;
                    break;
                case CharacterClass.Knight:
                    // 나이트: 마나, 마법 방어력, 물리 방어력 우선 증가
                    Health += 5;
                    Mana += 10;
                    PhysicalAttack += 2;
                    MagicalAttack += 3;
                    PhysicalDefense += 4;
                    MagicalDefense += 5;
                    Speed += 2;
                    HealingPower += 2;
                    SelfHealingPower += 1;
                    break;
                case CharacterClass.WhiteMage:
                    // 백마도사(WhiteMage): 타인 회복력과 마법 방어력, 마나 우선 증가
                    Health += 4;
                    Mana += 5;
                    PhysicalAttack += 1;
                    MagicalAttack += 3;
                    PhysicalDefense += 3;
                    MagicalDefense += 5;
                    Speed += 2;
                    HealingPower += 8;
                    SelfHealingPower += 4;
                    break;
                case CharacterClass.Monk:
                    // 수도승(Monk)
                    Health += 6;
                    Mana += 2;
                    PhysicalAttack += 7;
                    MagicalAttack += 1;
                    PhysicalDefense += 3;
                    MagicalDefense += 2;
                    Speed += 4;
                    HealingPower += 1;
                    SelfHealingPower += 1;
                    break;

                case CharacterClass.Dragoon:
                    // 용기사(Dragoon)
                    Health += 8;
                    Mana += 3;
                    PhysicalAttack += 6;
                    MagicalAttack += 2;
                    PhysicalDefense += 4;
                    MagicalDefense += 3;
                    Speed += 3;
                    HealingPower += 1;
                    SelfHealingPower += 1;
                    break;

                case CharacterClass.Bard:
                    // 음유시인(Bard)
                    Health += 4;
                    Mana += 3;
                    PhysicalAttack += 4;
                    MagicalAttack += 2;
                    PhysicalDefense += 2;
                    MagicalDefense += 2;
                    Speed += 6;
                    HealingPower += 3;
                    SelfHealingPower += 2;
                    break;

                case CharacterClass.BlackMage:
                    // 흑마도사(BlackMage)
                    Health += 3;
                    Mana += 6;
                    PhysicalAttack += 1;
                    MagicalAttack += 7;
                    PhysicalDefense += 2;
                    MagicalDefense += 4;
                    Speed += 2;
                    HealingPower += 2;
                    SelfHealingPower += 1;
                    break;
            }
        }

        public void GainExperience(int amount)
        {
            Experience += amount;
            CheckLevelUp();
        }

        private void CheckLevelUp()
        {
            // 경험치에 따른 레벨업 로직
            // 예: 100 경험치마다 레벨업
            while (Experience >= 100 * Level)
            {
                Experience -= 100 * Level;
                LevelUp();
            }
        }

        // 캐릭터 관련 추가 메소드나 프로퍼티
    }
}
