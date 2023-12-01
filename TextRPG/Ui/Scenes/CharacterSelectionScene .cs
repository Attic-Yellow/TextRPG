using System;
using System.Collections.Generic;
using System.Linq;
using TextRPG.Entity;
using TextRPG.Entity.Characters;
using TextRPG.Ui;
using static System.Net.Mime.MediaTypeNames;

namespace TextRPG.Ui.Scenes
{
    class CharacterSelectionScene : Scene
    {
        private int currentCharacterSelection = 0;
        private int currentJobSelection = 0;
        private string characterName = "";
        private List<Character> characters;
        private Character selectedCharacter;
        private bool isSelectingJob = false;
        private bool isEnteringName = false;
        private bool isGameStartEnabled = false;
        private int nameEntryCompletedCount = 0;
        private int maxCharacters = 4;
        private SceneManager sceneManager;

        public CharacterSelectionScene(SceneManager sceneManager)
        {
            this.sceneManager = sceneManager;
            characters = new List<Character>(new Character[maxCharacters]); // 4개의 비어 있는 캐릭터 슬롯
        }

        public override void Init()
        {
            Console.Clear();

            // 캐릭터 목록 초기화: 모든 슬롯을 null로 설정
            for (int i = 0; i < maxCharacters; i++)
            {
                characters.Add(null);
            }
            Render();
        }

        public override void Update()
        {
            if (isEnteringName)
            {
                EnterCharacterName();
            }
            else if (isSelectingJob)
            {
                SelectJob();
            }
            else
            {
                SelectCharacter();
            }

            if (nameEntryCompletedCount == maxCharacters)
            {
                // 모든 캐릭터의 이름이 입력되었다면, 다음 단계로 진행
                GoToMainMenu();
            }
            else
            {
                Render();
            }
        }

        public override void Render()
        {
            Console.Clear(); 
            int xPosition = (Console.WindowWidth - 20) / 2;
            int yPosition = (Console.WindowHeight / 2) - 1;

            if (isSelectingJob)
            {
                RenderJobSelection(); // 직업 선택 화면
                DisplayJobStats(); // 선택된 직업의 스테이터스 표시
            }
            else if (isEnteringName)
            {
                Console.SetCursorPosition(xPosition, yPosition);
                Console.WriteLine("사용하실 캐릭터 이름을 입력해 주세요:");
                Console.SetCursorPosition(xPosition, yPosition + 1);
                Console.WriteLine(characterName);
            }
            else
            {
                RenderCharacterSelection(); // 캐릭터 선택 화면
            }
        }

        private void RenderCharacterSelection()
        {
            int xPosition = (Console.WindowWidth - 5) / 2;
            int yPosition = (Console.WindowHeight / 2) - 1;
            int menuWidth = 50; // 메뉴 너비
            int itemCount = 4; // 메뉴 항목 개수
            UIRender.DrawBox(menuWidth, itemCount); // 박스 그리기
            for (int i = 0; i < maxCharacters; i++)
            {
                Console.SetCursorPosition(xPosition, yPosition + i);
                string characterDisplay = characters[i] != null ? $"{characters[i].Name} - {characters[i].GetJobClassNameInKorean()}" : "캐릭터 목록";
                if (i == currentCharacterSelection)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{characterDisplay} ◀");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(characterDisplay);
                }
            }
            if (isGameStartEnabled)
            {
                Console.SetCursorPosition(xPosition, yPosition + 6);
                Console.WriteLine("게임 시작");
            }
        }

        private void RenderJobSelection()
        {
            int xPosition = (Console.WindowWidth - 20) / 2;
            int yPosition = (Console.WindowHeight / 2) - 1;

            int menuWidth = 27; // 메뉴 너비
            int itemCount = 13; // 메뉴 항목 개수
            UIRender.DrawBox2(menuWidth, itemCount); // 박스 그리기

            var jobs = Enum.GetValues(typeof(CharacterClass)).Cast<CharacterClass>().ToList();
            for (int i = 0; i < jobs.Count; i++)
            {
                Console.SetCursorPosition(xPosition, yPosition + i);
                string jobName = GetJobClassNameInKorean(jobs[i]);
                if (i == currentJobSelection)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{jobName} ◀");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(jobName);
                }
            }
        }

        private void SelectCharacter()
        {
            var key = Console.ReadKey(intercept: true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    currentCharacterSelection = (currentCharacterSelection - 1 + maxCharacters) % maxCharacters;
                    break;
                case ConsoleKey.DownArrow:
                    currentCharacterSelection = (currentCharacterSelection + 1) % maxCharacters;
                    break;
                case ConsoleKey.Enter:
                    isSelectingJob = true;
                    selectedCharacter = new Character(" ", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0); // 새 캐릭터 인스턴스 생성
                    break;
            }
        }

        private void SelectJob()
        {
            var jobs = Enum.GetValues(typeof(CharacterClass)).Cast<CharacterClass>().ToList();
            var key = Console.ReadKey(intercept: true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    currentJobSelection = (currentJobSelection - 1 + jobs.Count) % jobs.Count;
                    break;
                case ConsoleKey.DownArrow:
                    currentJobSelection = (currentJobSelection + 1) % jobs.Count;
                    break;
                case ConsoleKey.Enter:
                    CreateCharacter(jobs[currentJobSelection]);
                    isSelectingJob = false;
                    isEnteringName = true;
                    break;
            }
        }

        private void EnterCharacterName()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                if (!string.IsNullOrWhiteSpace(characterName))
                {
                    selectedCharacter.Name = characterName;
                    characters[currentCharacterSelection] = selectedCharacter; // 캐릭터 목록 업데이트
                    characterName = ""; // 다음 입력을 위해 이름 초기화
                    isEnteringName = false; // 이름 입력 완료, 캐릭터 선택으로 돌아감
                    nameEntryCompletedCount++;
                    if (nameEntryCompletedCount == maxCharacters)
                    {
                        // 모든 캐릭터의 이름이 입력되었다면, 다음 단계로 진행
                        GoToMainMenu();
                    }
                }
            }
            else if (keyInfo.Key == ConsoleKey.Backspace && characterName.Length > 0)
            {
                characterName = characterName.Remove(characterName.Length - 1); // 마지막 문자 제거
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                characterName += keyInfo.KeyChar; // 입력된 문자 추가
            }
        }

        private void CreateCharacter(CharacterClass jobClass)
        {
            // 새 캐릭터 생성 및 초기화
            Character newCharacter = new Character("", jobClass, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            CharacterStatsManager.InitClass(newCharacter);
            characters[currentCharacterSelection] = newCharacter;
            selectedCharacter = newCharacter;
        }

        private void DisplayJobStats()
        {
            int xPosition = (Console.WindowWidth + 20) / 2;
            int yPosition = (Console.WindowHeight / 2) - 1;
            int menuWidth = 27; // 메뉴 너비
            int itemCount = 13; // 메뉴 항목 개수
            UIRender.DrawBox3(menuWidth, itemCount); // 박스 그리기

            Character tempCharacter = new Character("", (CharacterClass)currentJobSelection, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            CharacterStatsManager.InitClass(tempCharacter);

            Console.SetCursorPosition(xPosition, yPosition - 2);
            Console.WriteLine($"{GetJobClassNameInKorean((CharacterClass)currentJobSelection)} 직업 능력치:");
            Console.SetCursorPosition(xPosition, yPosition);
            Console.WriteLine($"체력: {tempCharacter.Health}");
            Console.SetCursorPosition(xPosition, yPosition + 1);
            Console.WriteLine($"마나: {tempCharacter.Mana}");
            Console.SetCursorPosition(xPosition, yPosition + 2);
            Console.WriteLine($"힘: {tempCharacter.PhysicalAttack}");
            Console.SetCursorPosition(xPosition, yPosition + 3);
            Console.WriteLine($"지능: {tempCharacter.MagicalAttack}");
            Console.SetCursorPosition(xPosition, yPosition + 4);
            Console.WriteLine($"방어력: {tempCharacter.PhysicalDefense}");
            Console.SetCursorPosition(xPosition, yPosition + 5);
            Console.WriteLine($"마법방어력: {tempCharacter.MagicalDefense}");
            Console.SetCursorPosition(xPosition, yPosition + 6);
            Console.WriteLine($"민첩: {tempCharacter.Speed}");
            Console.SetCursorPosition(xPosition, yPosition + 7);
            Console.WriteLine($"정신력: {tempCharacter.HealingPower}");
            Console.SetCursorPosition(xPosition, yPosition + 8);
            Console.WriteLine($"신앙: {tempCharacter.SelfHealingPower}");
            Console.SetCursorPosition(xPosition, yPosition + 9);
            Console.WriteLine($"행운: {tempCharacter.Luck}");
            Console.SetCursorPosition(xPosition, yPosition + 10);
            Console.WriteLine($"치명타: {tempCharacter.Critical}");
        }

        private string GetJobClassNameInKorean(CharacterClass jobClass)
        {
            switch (jobClass)
            {
                case CharacterClass.Warrior:
                    return "전사";
                case CharacterClass.Knight:
                    return "나이트";
                case CharacterClass.WhiteMage:
                    return "백마도사";
                case CharacterClass.Monk:
                    return "수도승";
                case CharacterClass.Dragoon:
                    return "용기사";
                case CharacterClass.Bard:
                    return "음유시인";
                case CharacterClass.BlackMage:
                    return "흑마도사";
                default:
                    return "알 수 없음";
            }
        }

        private void GoToMainMenu()
        {
            Console.WriteLine("메인 메뉴로 이동합니다...");
            Thread.Sleep(1000);
            sceneManager.ChangeScene(new MainMenuScene(sceneManager));
        }
    }
}
