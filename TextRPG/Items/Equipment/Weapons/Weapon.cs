using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Entity;
using static System.Net.Mime.MediaTypeNames;

namespace TextRPG.Items.Equipment.Weapons
{

    // 무기 종류
    // 도끼, 검, 백마도사 지팡이, 너클, 창, 활, 흑마도사 지팡이
    public enum WeaponType
    {
        Axe,
        Sword,
        WhiteMageStaff,
        Knuckle,
        Spear,
        Bow,
        BlackMageStaff
    }

    public class Weapon : EquipmentItem
    {
        // 데미지 계산식
        // 직업군에 따른 데미지 계산식
        // 전사 : ((무기 + 모자 + 상의 + 하의 + 신발 + 스테이터스 합의 힘 수치) - 민첩) / 2 + (체력 / 3) -> 물리 공격시
        // 나이트 : ((무기 + 모자 + 상의 + 하의 + 신발 + 스테이터스 합의 힘 수치) - 민첩) / 2 + (체력 / 3) -> 물리 공격시
        // 나이트 : ((무기 + 모자 + 상의 + 하의 + 신발 + 스테이터스 합의 지능 수치) - 정신력) / 2 + (마나 / 3) -> 마법 공격시
        // 백마도사 : ((무기 + 모자 + 상의 + 하의 + 신발 + 스테이터스 합의 정신력 수치) - 힘) / 2 + (마나 / 3) -> 마법 공격과 힐시전 시
        // 수도승 : ((무기 + 모자 + 상의 + 하의 + 신발 + 스테이터스 합의 힘 수치) - 신앙) / 2 + (체력 / 3) -> 물리 공격시
        // 용기사 : ((무기 + 모자 + 상의 + 하의 + 신발 + 스테이터스 합의 힘 수치) - 속도) / 2 + (체력 / 3) -> 물리 공격시
        // 음유시인 : ((무기 + 모자 + 상의 + 하의 + 신발 + 스테이터스 합의 민첩 수치) - 체력) / 2 + (마나 / 3) -> 물리 공격시
        // 흑마도사 : ((무기 + 모자 + 상의 + 하의 + 신발 + 스테이터스 합의 지능 수치) - 힘) / 2 + (마나 / 3) -> 마법 공격시

        public WeaponType WeaponType { get; set; }


        public Weapon(ItemGrade grade, string name, string description, WeaponType weaponType, int health, int mana, int physicalAttack, int magicalAttack, int physicalDefense, int magicalDefense, int speed, int healingPower, int selfHealingPower, int luck, int critical, int durability)
            : base(grade, name, description, EquipmentType.Weapon, health, mana, physicalAttack, magicalAttack, physicalDefense, magicalDefense, speed, healingPower, selfHealingPower, luck, critical, durability)
        {
            WeaponType = weaponType;
        }


    }

}
