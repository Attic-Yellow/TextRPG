using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Entity;
using TextRPG.Entity.Characters;
using TextRPG.Items;
using TextRPG.Items.Equipment.Weapons;

namespace TextRPG.DataManager
{
    public class PlayerData
    {

        public List<Character> characters { get; set; }
        public Character PlayerCharacter { get;  set; }
        public Inventory Inventory { get; private set; }

        private CharacterStatsManager characterStatsManager = new CharacterStatsManager();

        public PlayerData()
        {
            characters = new List<Character>();
            Inventory = new Inventory();
        }

        public Character GetLatestCharacter()
        {
            if (characters.Count == 0)
            {
                return null;
            }
            return characters[characters.Count - 1];
        }

        public void SetCharacter(Character character)
        {
            PlayerCharacter = character;
        }

        public List<Character> GetAllCharacters()
        {
            return characters;
        }

        public void AddCharacter(Character character)
        {
            characters.Add(character);
        }

        public void AddItemToInventory(EquipmentItem item)
        {
            Inventory.AddItem(item);
        }

        public bool RemoveItemFromInventory(EquipmentItem item)
        {
            return Inventory.RemoveItem(item);
        }

        public void EquipItemToCharacter(EquipmentItem item)
        {
            if (PlayerCharacter != null)
            {
                if (item is Weapon)
                {
                    PlayerCharacter.EquipWeapon(item as Weapon);
                }
                // 갑옷이나 기타 장비에 대한 처리...
            }
        }

        public void UnequipItemFromCharacter(EquipmentItem item)
        {
            if (PlayerCharacter != null)
            {
                if (item is Weapon)
                {
                    PlayerCharacter.UnequipWeapon();
                }
                // 갑옷이나 기타 장비에 대한 처리...
            }
        }

        public List<EquipmentItem> GetEquippedItems()
        {
            var equippedItems = new List<EquipmentItem>();

            if (PlayerCharacter != null)
            {
                if (PlayerCharacter.EquippedWeapon != null)
                {
                    equippedItems.Add(PlayerCharacter.EquippedWeapon);
                }
                // 기타 장비에 대한 추가...
            }

            return equippedItems;
        }

        public void LevelUp()
        {
            if (PlayerCharacter != null)
            {
                CharacterStatsManager.LevelUp(PlayerCharacter);
                // 추가적인 레벨 업 로직...
            }
        }
    }
}
