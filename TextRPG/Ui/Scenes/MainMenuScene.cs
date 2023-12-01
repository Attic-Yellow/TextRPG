using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Ui.Scenes
{
    class MainMenuScene : Scene
    {
        private SceneManager sceneManager;
        private int currentSelection = 0;
        private const int MaxMenuItems = 4;

        public MainMenuScene(SceneManager sceneManager)
        {
            this.sceneManager = sceneManager;
        }

        public override void Init()
        {
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
                        currentSelection = (currentSelection - 1 + MaxMenuItems) % MaxMenuItems;
                        break;
                    case ConsoleKey.DownArrow:
                        currentSelection = (currentSelection + 1) % MaxMenuItems;
                        break;
                    case ConsoleKey.Enter:
                        PerformActionBasedOnSelection();
                        break;
                }
                Render();
            }
        }

        public override void Render()
        {
            Console.Clear();
            PrintMenuItem("전투 탐색", 0);
            PrintMenuItem("캐릭터 메뉴", 1);
            PrintMenuItem("저장 하기", 2);
            PrintMenuItem("게임 종료", 3);
        }

        private void PrintMenuItem(string text, int index)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.WindowHeight / 2 - 2 + index);
            if (index == currentSelection)
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
                    // 전투 탐색 로직
                    break;
                case 1:
                    // 캐릭터 메뉴 로직
                    break;
                case 2:
                    // 저장 로직
                    break;
                case 3:
                    // 게임 종료 로직
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
