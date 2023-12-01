using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Ui.Scenes
{
    public class GameStartScene : Scene
    {
        private SceneManager sceneManager;

        private int currentSelection = 0; // 현재 선택된 항목의 인덱스

        public GameStartScene(SceneManager sceneManager)
        {
            this.sceneManager = sceneManager;
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
                        currentSelection = (currentSelection - 1 + 3) % 3;
                        shouldRender = true;
                        break;
                    case ConsoleKey.DownArrow:
                        currentSelection = (currentSelection + 1) % 3;
                        shouldRender = true;
                        break;
                    case ConsoleKey.Enter:
                        PerformActionBasedOnSelection();
                        break;
                }
                if (shouldRender)
                {
                    Render(); // 여기에서 Render 호출
                }
            }
        }

        public override void Render()
        {
            Console.Clear();

            int menuWidth = 50; // 메뉴 너비
            int itemCount = 3; // 메뉴 항목 개수
            UIRender.DrawBox(menuWidth, itemCount); // 박스 그리기

            RenderMenuItem("1. 처음부터", 0);
            RenderMenuItem("2. 이어하기", 1);
            RenderMenuItem("3. 게임 종료", 2);
        }

        private void RenderMenuItem(string text, int itemIndex)
        {

            int xPosition = (Console.WindowWidth - text.Length) / 2;
            int yPosition = (Console.WindowHeight / 2) - 1 + itemIndex; // 중앙을 기준으로 상하로 항목 배치

            Console.SetCursorPosition(xPosition, yPosition);
            if (currentSelection == itemIndex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{text} ◀");
                Console.ResetColor();
            }
            else
            {
                Console.Write($"{text}");
            }
            Console.WriteLine();
        }

        private void PerformActionBasedOnSelection()
        {
            switch (currentSelection)
            {
                case 0:
                    // "처음부터" 선택 시 로직
                    StartGame();
                    break;
                case 1:
                    // "이어하기" 선택 시 로직
                    // ContinueGame();
                    break;
                case 2:
                    // "게임 종료" 선택 시 로직
                    ExitGame();
                    break;
            }
        }

        private void StartGame()
        {
            // 게임 시작 로직 (예: 다른 장면으로 전환)
            Console.WriteLine("게임을 시작합니다...");
            Thread.Sleep(1000);
            sceneManager.ChangeScene(new CharacterSelectionScene(sceneManager));
        }

        private void ExitGame()
        {
            // 게임 종료 로직
            Console.WriteLine("게임을 종료합니다.");
            Environment.Exit(0);
        }
    }
}
