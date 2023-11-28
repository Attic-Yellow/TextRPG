using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TextRPG.DataManager;
using TextRPG.Entity;
using TextRPG.Items;
using TextRPG.Ui.BoxHandlers;
using TextRPG.Util;

namespace TextRPG.Ui
{
    class MainPageUI
    {
        private static PlayerData playerData;

        private static readonly List<string> mainMenuOptions = new List<string>
        {
            "탐색 하기", // 전투 관련 컨텐츠
            "캐릭터 메뉴", // 캐릭터 관리 및 인벤토리
            "상점 이용", // 상점 관련 시스템
            "저장 하기", // 게임 저장 시스템
            "게임 종료" // 게임 종료
        };

        private static readonly BoxHandler mainMenuBoxHandler = new BoxHandler(mainMenuOptions);

        public static void MainMenuDisplay(InputHandler inputHandler)
        {
            playerData = GameStartUI.GetPlayerData() ?? SingletonManager.GetInstance();

            bool conti = true;
            while (conti)
            {
                Console.Clear();
                UIRender.DrawBox(mainMenuBoxHandler.Box.Width, mainMenuBoxHandler.Box.Menus.Count);
                mainMenuBoxHandler.Display();

                var key = inputHandler.GetUserInput();
                mainMenuBoxHandler.Navigate(key);

                if (key == ConsoleKey.Enter || key == ConsoleKey.C)
                {
                    mainMenuPerformAction(inputHandler, mainMenuBoxHandler.Box.SelectedIndex);
                }
            }
        }

        private static void mainMenuPerformAction(InputHandler inputHandler, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0: // 탐색 하기
                    ExploreMenuDisplay(inputHandler);
                    break;
                case 1: // 캐릭터 메뉴
                    CharacterMenuDisplay(inputHandler);
                    break;
                case 2: // 상점 이용
                    // Shop functionality
                    break;
                case 3: // 저장 하기
                    SaveGame();
                    break;
                case 4: // 게임 종료
                    Environment.Exit(0);
                    break;
            }
        }

        private static void SaveGame()
        {
            if (playerData == null || playerData.GetAllCharacters().Count == 0)
            {
                Console.Clear();
                Console.WriteLine("저장할 데이터가 없습니다.");
                Thread.Sleep(1000);
                return;
            }

            GameData gameData = new GameData
            {
                // PlayerData에서 characters 리스트를 가져와 저장합니다.
                characters = playerData.GetAllCharacters()
            };

            gameData.SaveGame("TextRPG_SaveData.json");
            Console.Clear();
            Console.WriteLine("게임이 저장되었습니다.");
            Thread.Sleep(1000);
        }

        // 탐색 메뉴
        private static readonly List<string> exploreMenuOptions = new List<string>
        {
            "몬스터와 전투하기", // 몬스터와 전투
            "보스와 전투하기", // 보스와 전투
            "뒤로 가기" // 뒤로 가기
        };

        private static readonly BoxHandler exploreMenuBoxHandler = new BoxHandler(exploreMenuOptions);

        private static void ExploreMenuDisplay(InputHandler inputHandler)
        {
            bool continueDisplay = true;
            while (continueDisplay)
            {
                Console.Clear();
                UIRender.DrawBox(exploreMenuBoxHandler.Box.Width, exploreMenuBoxHandler.Box.Menus.Count);
                exploreMenuBoxHandler.Display();

                var key = inputHandler.GetUserInput();
                exploreMenuBoxHandler.Navigate(key);

                if (key == ConsoleKey.Enter || key == ConsoleKey.C)
                {
                    ExploreMenuPerformAction(inputHandler, exploreMenuBoxHandler.Box.SelectedIndex);
                }
                else if (key == ConsoleKey.Z)
                {

                }
                else if (key == ConsoleKey.X)
                {
                    // 뒤로 가기
                    CharacterMenuDisplay(inputHandler);
                    continueDisplay = false;
                }
            }
        }

        private static void ExploreMenuPerformAction(InputHandler inputHandler, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0: // 몬스터와 전투하기
                    // Monster battle functionality
                    break;
                case 1: // 보스와 전투하기
                    // Boss battle functionality
                    break;
                case 2: // 뒤로 가기
                    MainMenuDisplay(inputHandler);
                    break;
            }
        }

        // 캐릭터 메뉴
        // 캐릭터 메뉴는 캐릭터 관리, 스킬 관리, 인벤토리 관리, 뒤로 가기로 구성됩니다.
        // Ui폴더의 UIRender 클래스의 DrawCharacterMenuBox 메서드를 사용하여 캐릭터 메뉴를 구현합니다.
        // 1. 캐릭터
        // 2. 스킬
        // 3. 인벤토리
        // 4. 뒤로 가기
        private static readonly List<string> characterMenuOptions = new List<string>
        {
            "  캐릭터", // 캐릭터 관리
            "    스킬", // 스킬 관리
            " 인벤토리", // 인벤토리 관리
            "뒤로 가기" // 뒤로 가기
        };

        private static readonly BoxHandler characterMenuBoxHandler = new BoxHandler(characterMenuOptions);

        private static void CharacterMenuDisplay(InputHandler inputHandler)
        {
            bool continueDisplay = true;
            while (continueDisplay)
            {
                Console.Clear();
                UIRender.DrawCharacterMenuBox(characterMenuBoxHandler.Box.Width, characterMenuBoxHandler.Box.Menus.Count);
                characterMenuBoxHandler.GameMenuFirstDisplay();

                var key = inputHandler.GetUserInput();
                characterMenuBoxHandler.Navigate(key);

                if (key == ConsoleKey.Enter || key == ConsoleKey.C)
                {
                    CharacterMenuPerformAction(inputHandler, characterMenuBoxHandler.Box.SelectedIndex);
                }
                else if (key == ConsoleKey.Z)
                {
                    // 메인으로 가기
                    MainMenuDisplay(inputHandler);
                    continueDisplay = false;
                }
                else if (key == ConsoleKey.X)
                {
                    // 뒤로 가기
                    MainMenuDisplay(inputHandler);
                    continueDisplay = false;
                }
            }
        }

        private static void CharacterMenuPerformAction(InputHandler inputHandler, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0: // 캐릭터 관리
                    CharacterJobsDisplay(inputHandler);
                    break;
                case 1: // 스킬 관리
                    // Skill management functionality
                    break;
                case 2: // 인벤토리 관리
                    // Inventory management functionality
                    break;
                case 3: // 뒤로 가기
                    MainMenuDisplay(inputHandler);
                    break;
            }
        }

        // 캐릭터 관리
        // 캐릭터 관리는 4명의 캐릭터르 관리합니다.
        // 캐릭터 선택, 능력치 확인, 아이템 장착 및 해제, 소모품 사용로 구성됩니다.
        // 뒤로 가기는 Z키로 구성됩니다.
        // Ui폴더의 UIRender 클래스의 DrawCharacterMenuWorkBox 메서드를 사용하여 캐릭터 관리 메뉴를 구현합니다.
        // Ui폴더의 BoxHandlers 폴더의 BoxHandler 클래스의 GameMenuSecondOnlyPlayerDisplay 메서드를 사용하여 캐릭터 선택을 구현합니다.
        // 캐릭터 선택이 이루어지면 Ui폴더의 BoxHandlers 폴더의 BoxHandler 클래스의 GameMenuThirdDisplay 메서드를 사용하여 장비, 소모품을 구현합니다.
        // Ui폴더의 BoxHandlers 폴더의 BoxHandler 클래스의 GameMenuFourthDisplay 메서드를 사용하여 커서가 가르키는 캐릭터의 능력치를 보여줍니다.
        // DataMAnager 폴더의 PlayerData 클래스의 GetCharacter 메서드를 사용하여 캐릭터를 가져옵니다.
        private static void CharacterJobsDisplay(InputHandler inputHandler)
        {
            var playerData = SingletonManager.GetInstance();
            var characters = playerData.GetAllCharacters();
            var jobOptions = characters.Select(character => character.GetJobClassNameInKorean()).ToList();

            var jobBoxHandler = new BoxHandler(jobOptions);

            bool continueDisplay = true;
            while (continueDisplay)
            {
                Console.Clear();
                UIRender.DrawCharacterMenuBox(characterMenuBoxHandler.Box.Width, characterMenuBoxHandler.Box.Menus.Count);
                UIRender.DrawCharacterMenuWorkBox(jobBoxHandler.Box.Width, jobBoxHandler.Box.Menus.Count);
                characterMenuBoxHandler.GameMenuFirstDisplay();
                characterMenuBoxHandler.HighlightSelectedItem();
                jobBoxHandler.GameMenuSecondOnlyPlayerDisplay();
                jobBoxHandler.GameMenuFourthOnlyPlayerDisplay();

                var key = inputHandler.GetUserInput();
                jobBoxHandler.Navigate(key);

                if (key == ConsoleKey.Enter || key == ConsoleKey.C)
                {
                    int selectedCharacterIndex = jobBoxHandler.Box.SelectedIndex;

                    if (selectedCharacterIndex >= 0 && selectedCharacterIndex < characters.Count)
                    {
                        var selectedCharacter = characters[selectedCharacterIndex];
                        ChooseItemToUseDisplay(inputHandler, selectedCharacter, jobBoxHandler);
                    }
                    continueDisplay = false;
                }
                else if(key == ConsoleKey.Z)
                {
                    // 메인으로 가기
                    MainMenuDisplay(inputHandler);
                    continueDisplay = false;
                }
                else if(key == ConsoleKey.X)
                {
                    // 뒤로 가기
                    CharacterMenuDisplay(inputHandler);
                    continueDisplay = false;
                }
            }
        }

        private static readonly List<string> ChooseItemToUse = new List<string>
        {
            "장비 아이템", // 장비 착용 및 해제
            "소모품", // 소모품 사용
        };

        private static readonly BoxHandler ChooseItemToUseBoxHandler = new BoxHandler(ChooseItemToUse);

        private static void ChooseItemToUseDisplay(InputHandler inputHandler, Character selectedCharacter, BoxHandler jobBoxHandler)
        {
            bool continueDisplay = true;
            while (continueDisplay)
            {
                Console.Clear();
                UIRender.DrawCharacterMenuBox(characterMenuBoxHandler.Box.Width, characterMenuBoxHandler.Box.Menus.Count);
                UIRender.DrawCharacterMenuWorkBox(jobBoxHandler.Box.Width, jobBoxHandler.Box.Menus.Count);
                characterMenuBoxHandler.GameMenuFirstDisplay();
                characterMenuBoxHandler.HighlightSelectedItem();
                jobBoxHandler.GameMenuSecondOnlyPlayerDisplay();
                jobBoxHandler.GameMenuFourthOnlyPlayerDisplay();
                jobBoxHandler.HighlightSelectedItem();
                ChooseItemToUseBoxHandler.GameMenuThirdDisplay();

                var key = inputHandler.GetUserInput();
                ChooseItemToUseBoxHandler.Navigate(key);

                if (key == ConsoleKey.Enter || key == ConsoleKey.C)
                {
                    ChooseItemToUsePerformAction(inputHandler, ChooseItemToUseBoxHandler.Box.SelectedIndex, jobBoxHandler);
                    continueDisplay = false;
                }
                else if (key == ConsoleKey.Z)
                {
                    // 메인으로 가기
                    MainMenuDisplay(inputHandler);
                    continueDisplay = false;
                }
                else if (key == ConsoleKey.X)
                {
                    // 뒤로 가기
                    CharacterJobsDisplay(inputHandler);
                    continueDisplay = false;
                }
            }
        }

        private static void ChooseItemToUsePerformAction(InputHandler inputHandler, int selectedIndex, BoxHandler jobBoxHandler)
        {
            switch (selectedIndex)
            {
                case 0: // 장비 아이템
                    // 장비 선택
                    EquippedAndInventoryItemsDisplay(inputHandler, jobBoxHandler);

                    break;
                case 1: // 소모품
                    // Use item functionality
                    break;
            }
        }

        private static void EquippedAndInventoryItemsDisplay(InputHandler inputHandler, BoxHandler jobBoxHandler)
        {
            // SingletonManager를 통해 현재 선택된 캐릭터를 가져옵니다.
            var selectedCharacter = SingletonManager.GetInstance().PlayerCharacter;

            // 착용 중인 장비 목록 생성
            List<string> equippedItemNames = new List<string>();

            // 현재 착용 중인 장비 추가
            if (selectedCharacter.EquippedWeapon != null)
            {
                equippedItemNames.Add(selectedCharacter.EquippedWeapon.Name + " (착용 중)");
            }

            var itemBoxHandler = new BoxHandler(equippedItemNames);
            bool continueDisplay = true;

            while (continueDisplay)
            {
                Console.Clear();
                UIRender.DrawCharacterMenuBox(characterMenuBoxHandler.Box.Width, characterMenuBoxHandler.Box.Menus.Count);
                UIRender.DrawCharacterMenuWorkBox(jobBoxHandler.Box.Width, jobBoxHandler.Box.Menus.Count);
                characterMenuBoxHandler.GameMenuFirstDisplay();
                characterMenuBoxHandler.HighlightSelectedItem();
                jobBoxHandler.GameMenuSecondOnlyPlayerDisplay();
                jobBoxHandler.GameMenuFourthOnlyPlayerDisplay();
                jobBoxHandler.HighlightSelectedItem();
                ChooseItemToUseBoxHandler.GameMenuThirdDisplay();
                itemBoxHandler.GameMenuFifthOnlyPlayerDisplay();

                var key = inputHandler.GetUserInput();
                itemBoxHandler.Navigate(key);

                if (key == ConsoleKey.Enter || key == ConsoleKey.C)
                {
                    // 선택된 아이템에 대한 추가 로직 (선택적으로 구현)
                    continueDisplay = false;
                }
                else if (key == ConsoleKey.Z || key == ConsoleKey.X)
                {
                    // 뒤로 가기 또는 메인 메뉴로 가기
                    continueDisplay = false;
                }
            }
        }
    }
}
