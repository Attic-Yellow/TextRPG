using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.DataManager;
using TextRPG.Entity;
using TextRPG.Entity.Characters;
using TextRPG.Items;

namespace TextRPG.Ui.Scenes
{
    public class EquipmentManagementScene : Scene
    {
        private SceneManager sceneManager;
        private PlayerData playerData;
        private int currentCharacterSelection = 0;
        private int currentEquipmentSelection = 0;
        private List<Character> characters;

        public EquipmentManagementScene(SceneManager sceneManager)
        {
            this.sceneManager = sceneManager;
            this.playerData = SingletonManager.GetInstance();
            this.characters = playerData.GetAllCharacters();
        }

        public override void Init()
        {
            Console.Clear();
            Render();
        }

        public override void Update()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        currentEquipmentSelection = Math.Max(currentEquipmentSelection - 1, 0);
                        break;
                    case ConsoleKey.DownArrow:
                        currentEquipmentSelection = Math.Min(currentEquipmentSelection + 1, GetEquipmentCount() - 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        currentCharacterSelection = Math.Max(currentCharacterSelection - 1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        currentCharacterSelection = Math.Min(currentCharacterSelection + 1, characters.Count - 1);
                        break;
                    case ConsoleKey.Enter:
                        EquipSelectedEquipment();
                        break;
                }
                Render();
            }
        }

        public override void Render()
        {
            Console.Clear();
            RenderCharacterList();
            RenderCharacterStats();
            RenderEquipmentList();
        }

        private int GetEquipmentCount()
        {
            // 이 메서드는 선택된 캐릭터가 가진 장비의 수를 반환해야 합니다.
            // 임시로 0을 반환하고, 실제로는 캐릭터의 장비 수에 따라 반환값을 조정해야 합니다.
            return 0;
        }

        private void EquipSelectedEquipment()
        {
            var selectedCharacter = characters[currentCharacterSelection];
            var selectedEquipment = GetSelectedEquipment();

            // 장비 관리자를 사용하여 선택된 장비를 장착
            var equipmentManager = new EquipmentManager();
            equipmentManager.Equip(selectedCharacter, selectedEquipment);

            // 캐릭터의 스탯 업데이트 등의 추가 작업 수행
        }

        private EquipmentItem GetSelectedEquipment()
        {
            // 선택된 장비를 반환하는 로직을 구현합니다.
            // 이는 선택된 캐릭터의 인벤토리 또는 사용 가능한 장비 목록에서 선택된 장비를 찾는 로직을 포함해야 합니다.
            // 예시를 위한 간단한 구현:
            var selectedCharacter = characters[currentCharacterSelection];
            var inventory = playerData.Inventory.Items;

            // 임시로 첫 번째 장비를 선택된 장비로 가정합니다.
            return inventory.OfType<EquipmentItem>().FirstOrDefault();
        }

        private void RenderCharacterList()
        {
            for (int i = 0; i < characters.Count; i++)
            {
                var character = characters[i];
                string selectionMarker = i == currentCharacterSelection ? " ◀" : "";
                Console.WriteLine($"{character.Name} ({character.GetJobClassNameInKorean()}){selectionMarker}");
            }
        }

        private void RenderCharacterStats()
        {
            var selectedCharacter = characters[currentCharacterSelection];
            Console.WriteLine($"체력: {selectedCharacter.Health}");
            Console.WriteLine($"마나: {selectedCharacter.Mana}");
            // 추가 스테이터스 정보
        }

        private void RenderEquipmentList()
        {
            var selectedCharacter = characters[currentCharacterSelection];
            // 예시를 위한 가상의 장비 목록
            List<EquipmentItem> equipmentItems = new List<EquipmentItem>(); // 이를 캐릭터의 실제 장비 목록으로 대체해야 함

            for (int i = 0; i < equipmentItems.Count; i++)
            {
                var item = equipmentItems[i];
                string selectionMarker = i == currentEquipmentSelection ? " ◀" : "";
                Console.WriteLine($"{item.Name}{selectionMarker}");
            }
        }

        private void PerformActionBasedOnSelection()
        {
            var selectedCharacter = characters[currentCharacterSelection];
            var selectedEquipment = GetSelectedEquipment();

            if (selectedEquipment != null)
            {
                var equipmentManager = new EquipmentManager();
                equipmentManager.Equip(selectedCharacter, selectedEquipment);

                Console.WriteLine($"{selectedEquipment.Name}가 {selectedCharacter.Name}에게 장착되었습니다.");
                // 여기에 추가적인 UI 업데이트나 게임 로직을 구현할 수 있습니다.
            }
            else
            {
                Console.WriteLine("장착할 장비가 선택되지 않았습니다.");
            }
        }
    }
}
