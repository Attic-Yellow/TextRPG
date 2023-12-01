using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.DataManager;
using TextRPG.Entity;
using TextRPG.Items.Equipment.Weapons;
using TextRPG.Items.Equipment;
using TextRPG.Items;
using TextRPG.Entity.Characters;

namespace TextRPG
{
    public class GameInitializer
    {
        public void InitializeGame(PlayerData playerData)
        {
            // 모든 캐릭터에 기본 장비 할당
            foreach (var character in playerData.GetAllCharacters())
            {
                EquipCharacterWithCommonItems(character);
            }

            // 인벤토리에 커먼 모자 추가
            EquipmentItem commonHat = EquipmentFactory.CreateCommonHat();
            playerData.Inventory.AddItem(commonHat);
        }

        private void EquipCharacterWithCommonItems(Character character)
        {
            // 장비 관리자 인스턴스 생성
            var equipmentManager = new EquipmentManager();

            // 커먼 장비 생성 및 할당
            var commonWeapon = WeaponFactory.CreateCommonWeapon(character.JobClass.GetWeaponType());
            var commonTop = EquipmentFactory.CreateCommonTop();
            var commonGloves = EquipmentFactory.CreateCommonGloves();
            var commonBottom = EquipmentFactory.CreateCommonBottom();
            var commonShoes = EquipmentFactory.CreateCommonShoes();

            // 장비 장착
            equipmentManager.Equip(character, commonWeapon);
            equipmentManager.Equip(character, commonTop);
            equipmentManager.Equip(character, commonGloves);
            equipmentManager.Equip(character, commonBottom);
            equipmentManager.Equip(character, commonShoes);
        }
    }
}
