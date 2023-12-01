using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.DataManager;
using TextRPG.Ui;
using TextRPG.Ui.Scenes;

namespace TextRPG.GameEngine
{
    public class Engine
    {
        public bool IsRunning { get; private set; }

        private SceneManager sceneManager;


        public Engine()
        {
            IsRunning = true;
        }

        public void Start()
        {
            sceneManager = new SceneManager();
            Scene gameStartScene = new GameStartScene(sceneManager);
            sceneManager.ChangeScene(gameStartScene);

            GameLoop();
        }

        private void GameLoop()
        {
            while (IsRunning)
            {
                sceneManager.Update(); // 키 입력과 업데이트를 여기서 처리
                                       // Render() 메서드는 Update() 내에서 호출
            }
        }

        public void Exit()
        {
            // 필요한 정리 작업
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
