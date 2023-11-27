using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.DataManager;
using TextRPG.Ui;
using TextRPG.Util;

namespace TextRPG.GameEngine
{
    public class Engine
    {
        private InputHandler _inputHandler;
        private PlayerData _playerData;
        private GameState _currentGameState;

        public bool IsRunning { get; private set; }
         
        public Engine()
        {
            _inputHandler = new InputHandler();
            IsRunning = true;
            _currentGameState = GameState.StartMenu;
        }

        public void Start()
        {
            Init();
            GameLoop();
        }

        private void Init()
        {
            // 초기화 로직
            LoadGame();
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

        private void GameLoop()
        {
            while (IsRunning)
            {
                Update();
                Render();
            }
        }

        private void Update()
        {
            // 업데이트 로직
            switch (_currentGameState)
            {
                case GameState.StartMenu:
                    GameStartUI.StartMenuDisplay(_inputHandler);
                    break;
                case GameState.MainPage:
                    MainPageUI.MainMenuDisplay(_inputHandler);
                    break;
                    // 다른 상태에 대한 처리가 필요한 경우 여기에 추가
            }
        }

        private void Render()
        {
            // 렌더링 로직
            // 예: 사용자 인터페이스 갱신, 게임 화면 출력 등
        }

        public void Exit()
        {
            IsRunning = false;
        }
    }
    public enum GameState
    {
        StartMenu,
        MainPage,
    }
}
