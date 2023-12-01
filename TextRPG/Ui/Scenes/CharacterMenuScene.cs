using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.DataManager;

namespace TextRPG.Ui.Scenes
{
    public class CharacterMenuScene : Scene
    {
        private SceneManager sceneManager;
        private PlayerData playerData;
        private int currentSelection = 0;
        private const int MaxMenuItems = 4; // 최대 메뉴 항목 수

        public CharacterMenuScene(SceneManager sceneManager)
        {
            this.sceneManager = sceneManager;
            this.playerData = SingletonManager.GetInstance();
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
                bool shouldRender = false;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        currentSelection = (currentSelection - 1 + MaxMenuItems) % MaxMenuItems;
                        shouldRender = true;
                        break;
                    case ConsoleKey.DownArrow:
                        currentSelection = (currentSelection + 1) % MaxMenuItems;
                        shouldRender = true;
                        break;
                    case ConsoleKey.Enter:
                        PerformActionBasedOnSelection();
                        break;
                }
                if (shouldRender)
                {
                    Render();
                }
            }
        }

        public override void Render()
        {
            Console.Clear();
            PrintMenuItem("1. 장비 관리", 0);
            PrintMenuItem("2. 스킬 관리", 1);
            PrintMenuItem("3. 인벤토리", 2);
            PrintMenuItem("4. 뒤로 가기", 3);
        }

        private void PrintMenuItem(string text, int itemIndex)
        {
            int xPosition = (Console.WindowWidth - text.Length) / 2;
            int yPosition = (Console.WindowHeight / 2 - MaxMenuItems / 2) + itemIndex;

            Console.SetCursorPosition(xPosition, yPosition);
            if (currentSelection == itemIndex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{text} ◀");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(text);
            }
        }

        private void PerformActionBasedOnSelection()
        {
            switch (currentSelection)
            {
                case 0:
                    // 장비 관리 로직
                    GoEquipmentManagementScene();
                    break;
                case 1:
                    // 스킬 관리 로직
                    break;
                case 2:
                    // 인벤토리 로직
                    break;
                case 3:
                    GoBack();
                    break;
            }
        }

        private void GoEquipmentManagementScene()
        {
            Console.WriteLine("장비 관리로 이동합니다...");
            Thread.Sleep(500);
            sceneManager.ChangeScene(new EquipmentManagementScene(sceneManager));
        }

        private void GoBack()
        {
            Console.WriteLine("메인 메뉴로 돌아갑니다...");
            Thread.Sleep(500);
            sceneManager.ChangeScene(new MainMenuScene(sceneManager));
        }
    }
}
