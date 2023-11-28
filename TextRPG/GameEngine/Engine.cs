using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.DataManager;
using TextRPG.Ui;

namespace TextRPG.GameEngine
{
    public class Engine
    {
        public bool IsRunning { get; private set; }
        enum MoveDir { Up, Down, Left, Right, None }

        private MoveDir input;

        public Engine()
        {
        }

        public void Start()
        {
            Init();
            GameLoop();
        }

        private void Init()
        {
            // 초기화 로직
        }

        private void GameLoop()
        {
            while (IsRunning)
            {
                Input();
                Update();
                Render();
            }
        }

        private void Input()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            ConsoleKey key = keyInfo.Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    input = MoveDir.Up;
                    break;
                case ConsoleKey.DownArrow:
                    input = MoveDir.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    input = MoveDir.Left;
                    break;
                case ConsoleKey.RightArrow:
                    input = MoveDir.Right;
                    break;
                case ConsoleKey.Escape:
                    Exit();
                    break;
                default:
                    input = MoveDir.None;
                    break;
            }
        }

        private void Update()
        {
            // 업데이트 로직
            LoadGame();
        }

        private void Render()
        {
            // 렌더링 로직
            Console.Clear();

        }

        public void Exit()
        {
            IsRunning = false;
        }

        private void LoadGame()
        {
            GameData loadedData = GameData.LoadGameData();
            if (loadedData != null && loadedData.characters != null && loadedData.characters.Count > 0)
            {
                PlayerData PlayerData = new PlayerData();

                foreach (var character in loadedData.characters)
                {
                    if (character != null)
                    {
                        PlayerData.AddCharacter(character);
                        Console.WriteLine($"캐릭터 {character.Name} 로드됨");
                    }
                }
                SingletonManager.SetInstance(PlayerData);
            }
            else
            {
                PlayerData newPlayerData = new PlayerData();
                SingletonManager.SetInstance(newPlayerData);
                Console.WriteLine("새 게임 데이터 생성됨");
            }
        }
    }
}
