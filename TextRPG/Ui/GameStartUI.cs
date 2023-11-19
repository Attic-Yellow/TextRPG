using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.GameEngine;
using TextRPG.Ui.BoxHandlers;
using TextRPG.Util;

namespace TextRPG.Ui
{
    public class GameStartUI
    {
        private static readonly List<string> startMenuNumber = new List<string>
        {
            "처음부터", // 게임 시작
            "이어 하기", // 기존 게임 이어하기
            "설정", // 게임 설정
            "종료" // 게임 종료
        };

        private static readonly BoxHandler startMenuBoxHandler = new BoxHandler(startMenuNumber);

        public static void StartMenuDisplay(InputHandler inputHandler)
        {
            bool conti = true;
            while (conti)
            {
                Console.Clear();
                UIRender.DrawBox(startMenuBoxHandler.Box.Width, startMenuBoxHandler.Box.Menus.Count);
                startMenuBoxHandler.Display();

                var key = inputHandler.GetUserInput();
                startMenuBoxHandler.Navigate(key);
                if (key == ConsoleKey.Enter)
                {
                    PerformAction(inputHandler, startMenuBoxHandler.Box.SelectedIndex);
                    conti = false;
                }
            }
        }

        private static void PerformAction(InputHandler inputHandle, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0: // 처음부터
                    Console.Clear();
                    // 캐릭터 선택 UI를 여기서 호출합니다.
                    break;
                case 1: // 이어 하기

                    break;
                case 2: // 설정
                        // 설정 메뉴 로직을 구현하세요.
                    break;
                case 3: // 종료
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
