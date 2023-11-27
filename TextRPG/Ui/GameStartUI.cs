using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.DataManager;
using TextRPG.Entity;
using TextRPG.Entity.Characters;
using TextRPG.GameEngine;
using TextRPG.Items.Equipment.Weapons;
using TextRPG.Ui.BoxHandlers;
using TextRPG.Util;

namespace TextRPG.Ui
{
    public class GameStartUI
    {
        // 게임 시작 메뉴 UI를 구현합니다.
        // 1. 처음부터
        // 2. 이어 하기
        // 3. 설정
        // 4. 종료
        // 1, 2, 3, 4를 엔터키 입력 시 해당 메뉴로 이동합니다.
        private static int selectedCharacterCount = 0;
        private static PlayerData playerData = new PlayerData();

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
                BoxHandler.DisplayGuide();

                var key = inputHandler.GetUserInput();
                startMenuBoxHandler.Navigate(key);
                if (key == ConsoleKey.Enter)
                {
                    StartMenuPerformAction(inputHandler, startMenuBoxHandler.Box.SelectedIndex);
                    conti = false;
                }
            }
        }

        private static void StartMenuPerformAction(InputHandler inputHandler, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0: // 게임 시작
                    Console.Clear();
                    // 캐릭터 선택 UI를 여기서 호출합니다.
                    CharacterMenuDisplay(inputHandler);
                    break;
                case 1: // 기존 게임 이어하기
                    LoadExistingGame(inputHandler);
                    break;
                case 2: // 게임 설정
                    Console.Clear();
                    // 게임 설정 UI를 여기서 호출합니다.
                    SettingMenuDisplay(inputHandler);
                    break;
                case 3: // 게임 종료
                    Environment.Exit(0);
                    break;
            }
        }

        // 캐릭터 선택 UI를 구현합니다.
        // Ui폴더의 UiRender클래스를 이용하여 박스를 그립니다.
        // Entity폴더에서 Character 클래스에 직업을 출력하고 커서가 가르키는 직업의 능력치를 출력합니다.
        // 커서가 가르키는 직업의 능력치를 출력할 때, 능력치가 빨간색으로 출력합니다.
        // 1. 전사
        // 2. 나이트
        // 3. 백마도사
        // 4. 수도승
        // 5. 용기사
        // 6. 음유시인
        // 7. 흑마도사
        // 8. 뒤로 가기
        // 1, 2, 3, 4, 5, 6, 7, 8을 엔터키 입력시 해당 메뉴로 이동합니다.
        private static readonly List<string> characterMenuNumber = new List<string>
        {
            "전사", // 전사
            "나이트", // 나이트
            "백마도사", // 백마도사
            "수도승", // 수도승
            "용기사", // 용기사
            "음유시인", // 음유시인
            "흑마도사", // 흑마도사
            "뒤로 가기" // 뒤로 가기
        };

        private static readonly BoxHandler characterMenuBoxHandler = new BoxHandler(characterMenuNumber);

        private static Character currentSelectedCharacter;

        public static void CharacterMenuDisplay(InputHandler inputHandler)
        {

            while (selectedCharacterCount < 4)
            {
                Console.Clear();
                UpdateSelectedCharacter(characterMenuBoxHandler.Box.SelectedIndex);
                UIRender.DrawBox(characterMenuBoxHandler.Box.Width, characterMenuBoxHandler.Box.Menus.Count);
                characterMenuBoxHandler.Display();
                CharacterStatsDisplay(currentSelectedCharacter);
                CharacterEquipStatsDisplay(currentSelectedCharacter);
                DisplaySelectedCharacterInfo();
                BoxHandler.DisplayGuide();
                var key = inputHandler.GetUserInput();
                characterMenuBoxHandler.Navigate(key);

                if (key == ConsoleKey.Enter)
                {   
                    // 캐릭터 이름 설정 UI를 여기서 호출합니다.
                    CharacterMenuPerformAction(inputHandler, characterMenuBoxHandler.Box.SelectedIndex);
                }
                else if (key == ConsoleKey.Z)
                {
                    // 시작 화면 UI로 돌아가기
                    StartMenuDisplay(inputHandler);
                }
                else if (key == ConsoleKey.X)
                {
                    // 뒤로 가기
                    StartMenuDisplay(inputHandler);
                }

            }
            MainPageUI.MainMenuDisplay(inputHandler); 
        }

        private static void UpdateSelectedCharacter(int selectedIndex)
        {
            currentSelectedCharacter = CreateCharacterForClass((CharacterClass)selectedIndex);
        }

        private static void CharacterMenuPerformAction(InputHandler inputHandler, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0: // 전사
                    Console.Clear();
                    // 캐릭터 이름 설정 UI를 여기서 호출합니다.
                    currentPlayerCharacter = CreateCharacterForClass((CharacterClass)selectedIndex);
                    CharacterNameDisplay(inputHandler);
                    break;
                case 1: // 나이트
                    Console.Clear();
                    // 캐릭터 이름 설정 UI를 여기서 호출합니다.
                    currentPlayerCharacter = CreateCharacterForClass((CharacterClass)selectedIndex);
                    CharacterNameDisplay(inputHandler);
                    break;
                case 2: // 백마도사
                    Console.Clear();
                    // 캐릭터 이름 설정 UI를 여기서 호출합니다.
                    currentPlayerCharacter = CreateCharacterForClass((CharacterClass)selectedIndex);
                    CharacterNameDisplay(inputHandler);
                    break;
                case 3: // 수도승
                    Console.Clear();
                    // 캐릭터 이름 설정 UI를 여기서 호출합니다.
                    currentPlayerCharacter = CreateCharacterForClass((CharacterClass)selectedIndex);
                    CharacterNameDisplay(inputHandler);
                    break;
                case 4: // 용기사
                    Console.Clear();
                    // 캐릭터 이름 설정 UI를 여기서 호출합니다.
                    currentPlayerCharacter = CreateCharacterForClass((CharacterClass)selectedIndex);
                    CharacterNameDisplay(inputHandler);
                    break;
                case 5: // 음유시인
                    Console.Clear();
                    // 캐릭터 이름 설정 UI를 여기서 호출합니다.
                    currentPlayerCharacter = CreateCharacterForClass((CharacterClass)selectedIndex);
                    CharacterNameDisplay(inputHandler);
                    break;
                case 6: // 흑마도사
                    Console.Clear();
                    // 캐릭터 이름 설정 UI를 여기서 호출합니다.
                    currentPlayerCharacter = CreateCharacterForClass((CharacterClass)selectedIndex);
                    CharacterNameDisplay(inputHandler);
                    break;
                case 7: // 뒤로 가기
                    StartMenuDisplay(inputHandler);
                    break;
            }
        }

        // 캐릭터 클래스에 따라 캐릭터를 생성합니다.
        // Entity폴더의 Character클래스를 참고하여 캐릭터를 생성합니다.
        // 캐릭터를 생성할 때, 캐릭터 클래스에 따라 능력치를 설정합니다.
        // 캐릭터 클래스에 따라 능력치를 설정할 때, 능력치는 랜덤으로 설정합니다.
        private static Character CreateCharacterForClass(CharacterClass characterClass)
        {
            string name = "Default Name";
            Character character = new Character(name, characterClass, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            character.JobClass = characterClass;
            CharacterStatsManager.InitClass(character);
            return character;
        }

        private static void CharacterStatsDisplay(Character character)
        {
            if (character == null) return;

            int boxX = (Console.WindowWidth - 110) / 2 + 3;
            int boxY = (Console.WindowHeight + 1) / 2 + 5;
            int boxWidth = 55;
            int boxHeight = 18;

            EquipmentStats totalStats = character.GetTotalEquipmentStats();

            UIRender.DrawBoxWithPosition(boxX, boxY, boxWidth, boxHeight);
            DisplayCharacterStats(character, totalStats);
        }

        private static void DisplayCharacterStats(Character character, EquipmentStats totalStats)
        {
            Console.SetCursorPosition((Console.WindowWidth - 70) / 2 + 3, (Console.WindowHeight + 5) / 2 + 5);
            Console.Write($"레벨:\t{character.Level} ");
            Console.SetCursorPosition((Console.WindowWidth - 70) / 2 + 3, (Console.WindowHeight + 5) / 2 + 7);
            Console.Write($"직업 스탯 : 장비 미착용 / 착용");
            Console.SetCursorPosition((Console.WindowWidth - 70) / 2 + 3, (Console.WindowHeight + 5) / 2 + 8);
            Console.Write($"체력:\t\t{character.Health} / {totalStats.Health}");
            Console.SetCursorPosition((Console.WindowWidth - 70) / 2 + 3, (Console.WindowHeight + 5) / 2 + 9);
            Console.Write($"마나:\t\t{character.Mana} / {totalStats.Mana}");
            Console.SetCursorPosition((Console.WindowWidth - 70) / 2 + 3, (Console.WindowHeight + 5) / 2 + 10);
            Console.Write($" 힘:\t\t{character.PhysicalAttack} / {totalStats.PhysicalAttack}");
            Console.SetCursorPosition((Console.WindowWidth - 70) / 2 + 3, (Console.WindowHeight + 5) / 2 + 11);
            Console.Write($"지능:\t\t{character.MagicalAttack} / {totalStats.MagicalAttack}");
            Console.SetCursorPosition((Console.WindowWidth - 70) / 2 + 3, (Console.WindowHeight + 5) / 2 + 12);
            Console.Write($"물리 방어력:\t{character.PhysicalDefense} / {totalStats.PhysicalDefense}");
            Console.SetCursorPosition((Console.WindowWidth - 70) / 2 + 3, (Console.WindowHeight + 5) / 2 + 13);
            Console.Write($"마법 방어력:\t{character.MagicalDefense} / {totalStats.MagicalDefense}");
            Console.SetCursorPosition((Console.WindowWidth - 70) / 2 + 3, (Console.WindowHeight + 5) / 2 + 14);
            Console.Write($"민첩:\t\t{character.Speed} / {totalStats.Speed}");
            Console.SetCursorPosition((Console.WindowWidth - 70) / 2 + 3, (Console.WindowHeight + 5) / 2 + 15);
            Console.Write($"정신력:\t\t{character.HealingPower} / {totalStats.HealingPower}");
            Console.SetCursorPosition((Console.WindowWidth - 70) / 2 + 3, (Console.WindowHeight + 5) / 2 + 16);
            Console.Write($"신앙:\t\t{character.SelfHealingPower} / {totalStats.SelfHealingPower}");
            Console.SetCursorPosition((Console.WindowWidth - 70) / 2 + 3, (Console.WindowHeight + 5) / 2 + 17);
            Console.Write($"행운:\t\t{character.Luck} / {totalStats.Luck}");
            Console.SetCursorPosition((Console.WindowWidth - 70) / 2 + 3, (Console.WindowHeight + 5) / 2 + 18);
            Console.Write($"치명타 확률:\t{character.Critical} / {totalStats.Critical}");
        }

        private static void CharacterEquipStatsDisplay(Character character)
        {
            if (character == null) return;
            EquipmentStats totalStats = character.GetTotalEquipmentStats();

            int boxX = (Console.WindowWidth + 0) / 2 + 3;
            int boxY = (Console.WindowHeight + 1) / 2 + 5;
            int boxWidth = 55;
            int boxHeight = 18;

            UIRender.DrawBoxWithPosition(boxX, boxY, boxWidth, boxHeight);
            DisplayEquipmentStats(totalStats);
        }

        private static void DisplayEquipmentStats(EquipmentStats totalStats)
        {
            Console.SetCursorPosition((Console.WindowWidth + 40) / 2 + 3, (Console.WindowHeight + 5) / 2 + 5);
            Console.Write($"장비 능력치 총합");

            Console.SetCursorPosition((Console.WindowWidth + 40) / 2 + 3, (Console.WindowHeight + 5) / 2 + 7);
            Console.Write($"체력:\t\t{totalStats.Health}");
            Console.SetCursorPosition((Console.WindowWidth + 40) / 2 + 3, (Console.WindowHeight + 5) / 2 + 8);
            Console.Write($"마나:\t\t{totalStats.Mana}");
            Console.SetCursorPosition((Console.WindowWidth + 40) / 2 + 3, (Console.WindowHeight + 5) / 2 + 9);
            Console.Write($" 힘:\t\t\t{totalStats.PhysicalAttack}");
            Console.SetCursorPosition((Console.WindowWidth + 40) / 2 + 3, (Console.WindowHeight + 5) / 2 + 10);
            Console.Write($"지능:\t\t{totalStats.MagicalAttack}");
            Console.SetCursorPosition((Console.WindowWidth + 40) / 2 + 3, (Console.WindowHeight + 5) / 2 + 11);
            Console.Write($"물리 방어력:\t\t{totalStats.PhysicalDefense}");
            Console.SetCursorPosition((Console.WindowWidth + 40) / 2 + 3, (Console.WindowHeight + 5) / 2 + 12);
            Console.Write($"마법 방어력:\t\t{totalStats.MagicalDefense}");
            Console.SetCursorPosition((Console.WindowWidth + 40) / 2 + 3, (Console.WindowHeight + 5) / 2 + 13);
            Console.Write($"민첩:\t\t{totalStats.Speed}");
            Console.SetCursorPosition((Console.WindowWidth + 40) / 2 + 3, (Console.WindowHeight + 5) / 2 + 14);
            Console.Write($"정신력:\t\t{totalStats.HealingPower}");
            Console.SetCursorPosition((Console.WindowWidth + 40) / 2 + 3, (Console.WindowHeight + 5) / 2 + 15);
            Console.Write($"신앙:\t\t{totalStats.SelfHealingPower}");
            Console.SetCursorPosition((Console.WindowWidth + 40) / 2 + 3, (Console.WindowHeight + 5) / 2 + 16);
            Console.Write($"행운:\t\t{totalStats.Luck}");
            Console.SetCursorPosition((Console.WindowWidth + 40) / 2 + 3, (Console.WindowHeight + 5) / 2 + 17);
            Console.Write($"치명타 확률:\t\t{totalStats.Critical}");
        }

        private static void DisplaySelectedCharacterInfo()
        {
            List<Character> characters = playerData.GetAllCharacters();
            if (characters == null || characters.Count == 0)
            {
                return;
            }

            int boxX = -12;
            int boxY = (Console.WindowHeight - 24);
            int boxWidth = 20;
            int boxHeight = 6; // 각 캐릭터 박스의 높이

            for (int i = 0; i < characters.Count; i++)
            {
                DisplayCharacterBox(characters[i], boxX + boxWidth * (i + 1), boxY, boxWidth, boxHeight);
            }
        }

        private static void DisplayCharacterBox(Character character, int boxX, int boxY, int boxWidth, int boxHeight)
        {
            UIRender.DrawBoxWithPosition(boxX, boxY, boxWidth, boxHeight);
            Console.SetCursorPosition(boxX + 3, (Console.WindowHeight - 22));
            Console.WriteLine($"직업: {character.JobClass}");
            Console.SetCursorPosition(boxX + 3, (Console.WindowHeight - 21));
            Console.WriteLine($"이름: {character.Name}");
        }

        // 캐릭터 이름 설정 UI를 구현합니다.
        // Ui폴더의 UIRender클래스를 참고하여 박스를 그립니다.
        // 이름을 입력하세요. 라는 메시지를 출력하고, 이름을 입력받습니다.
        // 이름을 성공적으로 설정하면, [ name ]으로 이름이 설정되었습니다. 라는 메시지를 출력합니다.
        // Entity폴더의 Character클래스의 직업 능력치와 이름을 PlayerData클래스에 저장한 뒤, 선택 UI로 돌아갑니다.
        private static Character currentPlayerCharacter;

        private static void CharacterNameDisplay(InputHandler inputHandler)
        {
            Console.Clear();
            UIRender.DrawBox(60, 3);
            Console.SetCursorPosition((Console.WindowWidth - 60) / 2 + 5, (Console.WindowHeight - 3) / 2 + 3);
            UIRender.DrawCenteredStringInBox("이름을 입력하세요.", 60);
            Console.SetCursorPosition((Console.WindowWidth - 60) / 2 + 5, (Console.WindowHeight - 3) / 2 + 1);
            Console.Write("이름: ");
            string name = Console.ReadLine();
            
            if (currentPlayerCharacter != null)
            {
                currentPlayerCharacter.Name = name;
                playerData.AddCharacter(currentPlayerCharacter);
                selectedCharacterCount++;
            }

            Console.Clear();
            UIRender.DrawBox(60, 3);
            Console.SetCursorPosition((Console.WindowWidth - 60) / 2, (Console.WindowHeight - 3) / 2 + 2);
            UIRender.DrawCenteredStringInBox($"[ {name} ]으로 이름이 설정되었습니다.", 60);
            Console.SetCursorPosition((Console.WindowWidth - 60) / 2, (Console.WindowHeight - 3) / 2 + 3);
            UIRender.DrawCenteredStringInBox("EnterKey를 눌러 주세요.", 60);
            Console.ReadKey();
            CharacterMenuDisplay(inputHandler);
        }


        // 게임 설정 UI를 구현합니다.
        // Ui폴더의 UIRender클래스를 참고하여 박스를 그립니다.
        // 1. 난이도
        // 2. 뒤로 가기
        // 1, 2를 엔터키 입력 시 해당 메뉴로 이동합니다.
        private static readonly List<string> settingMenuNumber = new List<string>
        {
            "난이도", // 난이도
            "뒤로 가기" // 뒤로 가기
        };

        private static readonly BoxHandler settingMenuBoxHandler = new BoxHandler(settingMenuNumber);

        public static void SettingMenuDisplay(InputHandler inputHandler)
        {
            bool conti = true;
            while (conti)
            {
                Console.Clear();
                UIRender.DrawBox(settingMenuBoxHandler.Box.Width, settingMenuBoxHandler.Box.Menus.Count);
                settingMenuBoxHandler.Display();

                var key = inputHandler.GetUserInput();
                settingMenuBoxHandler.Navigate(key);
                if (key == ConsoleKey.Enter)
                {
                    SettingMenuPerformAction(inputHandler, settingMenuBoxHandler.Box.SelectedIndex);
                    conti = false;
                }
                else if (key == ConsoleKey.Z)
                {

                }
                else if (key == ConsoleKey.X)
                {
                    // 뒤로 가기
                    StartMenuDisplay(inputHandler);
                }
            }
        }

        private static void SettingMenuPerformAction(InputHandler inputHandler, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0: // 난이도
                    Console.Clear();
                    // 난이도 설정 UI를 여기서 호출합니다.
                    break;
                case 1: // 뒤로 가기
                    StartMenuDisplay(inputHandler);
                    break;
            }
        }

        private static void LoadExistingGame(InputHandler inputHandler)
        {
            GameData loadedData = GameData.LoadGameData();

            if (loadedData != null && loadedData.characters != null && loadedData.characters.Any())
            {
                playerData = new PlayerData();
                foreach (var character in loadedData.characters)
                {
                    playerData.AddCharacter(character);
                }

                selectedCharacterCount = playerData.GetAllCharacters().Count;
                Console.Clear();
                Console.WriteLine("저장된 게임을 성공적으로 불러왔습니다.");
                Thread.Sleep(1000);
                MainPageUI.MainMenuDisplay(inputHandler);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("저장된 게임이 없습니다. 새 게임을 시작하시겠습니까? (Y/N)");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Y)
                {
                    CharacterMenuDisplay(inputHandler);
                }
                else
                {
                    StartMenuDisplay(inputHandler);
                }
            }
        }

        public static PlayerData GetPlayerData()
        {
        return playerData;
        }

    }
}