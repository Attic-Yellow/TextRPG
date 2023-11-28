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
        private CharacterStatsManager characterStatsManager = new CharacterStatsManager();

        public List<Character> characters { get; set; }
        public Character PlayerCharacter { get;  set; }
        public Inventory Inventory { get; private set; }

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
