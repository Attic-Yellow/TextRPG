using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.DataManager;
using TextRPG.Items.Equipment.Weapons;

namespace TextRPG.Ui.BoxHandlers
{
    public class Box
    {
        public List<string> Menus { get; set; }
        public int SelectedIndex { get; private set; } = 0;
        public int Width { get; set; } = 40;
        public int Padding { get; set; } = 2;
        public int SelectedItemTopOffset { get; set; }
        public int SelectedItemLeftOffset { get; set; }

        public Box(List<string> menus)
        {
            Menus = menus;
        }

        public void NextItem()
        {
            SelectedIndex = (SelectedIndex + 1) % Menus.Count;
        }

        public void PreviousItem()
        {
            SelectedIndex = (SelectedIndex - 1 + Menus.Count) % Menus.Count;
        }
    }

    public class BoxHandler
    {
        public Box Box { get; private set; }

        public BoxHandler(List<string> menuNumbers, int width = 110)
        {
            Box = new Box(menuNumbers) { Width = width };
        }

        // Z = 시작 화면으로 가기
        // X = 뒤로 가기
        // C or 엔터 = 확인
        // 를 한 줄로 알려 주는 안내문 출력
        public static void DisplayGuide()
        {
            Console.SetCursorPosition((Console.WindowWidth) / 2 - 50, (Console.WindowHeight) / 2 - 1);
            Console.WriteLine("【 Z ⇒ 시작 화면으로 가기 】");
            Console.SetCursorPosition((Console.WindowWidth) / 2 - 50, (Console.WindowHeight) / 2);
            Console.WriteLine("【 X ⇒ 뒤로 가기 】");
            Console.SetCursorPosition((Console.WindowWidth) / 2 - 50, (Console.WindowHeight) / 2 + 1);
            Console.WriteLine("【 C/엔터 ⇒ 확인 】");
        }

        public void Display()
        {
            int topOffset = (Console.WindowHeight - Box.Menus.Count) / 2;

            for (int i = 0; i < Box.Menus.Count; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth - Box.Width) / 2 + 2, topOffset + i + 1);

                if (i == Box.SelectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    UIRender.DrawCenteredStringInBox($"{Box.Menus[i]} ◀", Box.Width);
                    Console.ResetColor();
                }
                else
                {
                    UIRender.DrawCenteredStringInBox($"  {Box.Menus[i]}", Box.Width);
                }
            }
        }

        // 캐릭터 메뉴 첫번째 화면
        public void GameMenuFirstDisplay()
        {
            int topOffset = (Console.WindowHeight - Box.Menus.Count) / 2 - 9;
            int leftOffset = (Console.WindowWidth - Box.Width) / 2 + 5;
            int spaceBetween = (Box.Width - Box.Menus.Sum(s => s.Length)) / (Box.Menus.Count);

            Box.SelectedItemTopOffset = topOffset + Box.SelectedIndex;
            Box.SelectedItemLeftOffset = leftOffset;

            Console.SetCursorPosition(leftOffset, topOffset);
            for (int i = 0; i < Box.Menus.Count; i++)
            {

                if (i == Box.SelectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(Box.Menus[i] + " ◀");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(Box.Menus[i]);
                }

                if (i < Box.Menus.Count - 1)
                {
                    Console.Write(new string(' ', spaceBetween));
                }
            }
            Console.WriteLine();
        }

        public void GameMenuSecondDisplay()
        {
            int topOffset = (Console.WindowHeight - Box.Menus.Count) / 2 - 8;
            int leftOffset = (Console.WindowWidth - Box.Width) / 2 + (15 - 3);
            int spaceBetween = (Box.Width / 2) - 40;

            Box.SelectedItemTopOffset = topOffset + Box.SelectedIndex;
            Box.SelectedItemLeftOffset = leftOffset;

            Console.SetCursorPosition(leftOffset, topOffset);

            for (int i = 0; i < Box.Menus.Count; i++)
            {

                if (i == Box.SelectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(Box.Menus[i] + " ◀");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(Box.Menus[i]);
                }

                if (i < Box.Menus.Count - 1)
                {
                    Console.Write(new string(' ', spaceBetween));
                }
            }
        }

        public void GameMenuSecondOnlyPlayerDisplay()
        {
            int maxLength = Box.Menus.Max(name => name.Length); // 가장 긴 캐릭터 이름의 길이
            const int maxDisplayCount = 3; // 한 번에 표시할 최대 캐릭터 수
            int displayStartIndex = Math.Max(Box.SelectedIndex - maxDisplayCount / 2, 0);
            displayStartIndex = Math.Min(displayStartIndex, Math.Max(Box.Menus.Count - maxDisplayCount, 0));

            bool hasPrevious = displayStartIndex > 0; // 이전 캐릭터가 존재하는지
            bool hasNext = (displayStartIndex + maxDisplayCount) < Box.Menus.Count; // 다음 캐릭터가 존재하는지

            int topOffset = (Console.WindowHeight - maxDisplayCount) / 2 - 7;
            int leftOffset = (Console.WindowWidth - 97) / 2;
            int spaceBetween = (maxLength / 2);

            int selectedItemRelativeIndex = Box.SelectedIndex - displayStartIndex;

            Console.SetCursorPosition(leftOffset, topOffset);

            // 이전 캐릭터가 존재하면 화살표 표시
            if (hasPrevious) Console.Write("← ");

            for (int i = 0; i < maxDisplayCount; i++)
            {
                int actualIndex = i + displayStartIndex;
                if (actualIndex >= Box.Menus.Count) break; // 목록 범위를 벗어나면 중단

                if (actualIndex == Box.SelectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"【 {Box.Menus[actualIndex]} 】◀");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"【 {Box.Menus[actualIndex]} 】");
                }

                if (i < maxDisplayCount - 1)
                {
                    Console.Write(new string(' ', spaceBetween));
                }
            }

            // 다음 캐릭터가 존재하면 화살표 표시
            if (hasNext) Console.Write(" →");
        }

        public void GameMenuThirdDisplay()
        {
            int topOffset = (Console.WindowHeight - Box.Menus.Count) / 2 - 8;
            int leftOffset = (Console.WindowWidth - Box.Width) / 2 + (65 - Box.Menus.Count);
            int spaceBetween = (Box.Width / 2) - 35;

            Box.SelectedItemTopOffset = topOffset + Box.SelectedIndex;
            Box.SelectedItemLeftOffset = leftOffset;

            Console.SetCursorPosition(leftOffset, topOffset);
            for (int i = 0; i < Box.Menus.Count; i++)
            {


                if (i == Box.SelectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(Box.Menus[i] + " ◀");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(Box.Menus[i]);
                }

                if (i < Box.Menus.Count - 1)
                {
                    Console.Write(new string(' ', spaceBetween));
                }
            }
        }

        public void GameMenuFourthDisplay()
        {
            int topOffset = (Console.WindowHeight - Box.Menus.Count) / 2 - 2;
            int leftOffset = (Console.WindowWidth - Box.Width) / 2 + (15 - Box.Menus.Count);

            for (int i = 0; i < Box.Menus.Count; i++)
            {
                Console.SetCursorPosition(leftOffset, topOffset++);

                if (i == Box.SelectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(Box.Menus[i] + " ◀");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(Box.Menus[i]);
                }

                if (i < Box.Menus.Count - 1)
                {
                    Console.WriteLine();
                }
            }
        }


        public void GameMenuFourthOnlyPlayerDisplay()
        {
            var playerData = SingletonManager.GetInstance();
            var characters = playerData.GetAllCharacters();
            if (Box.SelectedIndex < characters.Count)
            {
                var selectedCharacter = characters[Box.SelectedIndex];
                var equippedWeapon = selectedCharacter.EquippedWeapon;

                int topOffset = (Console.WindowHeight - Box.Menus.Count) / 2 - 5;
                int leftOffset = (Console.WindowWidth - Box.Width) / 2 + (15 - Box.Menus.Count);

                Console.SetCursorPosition(leftOffset, topOffset);
                Console.WriteLine($"이름: {selectedCharacter.Name}");
                Console.SetCursorPosition(leftOffset, topOffset + 2);
                Console.WriteLine($"레벨: {selectedCharacter.Level}");
                Console.SetCursorPosition(leftOffset, topOffset + 3);
                Console.WriteLine($"경험치: {selectedCharacter.Experience}");
                Console.SetCursorPosition(leftOffset, topOffset + 4);
                Console.WriteLine($"체력: {selectedCharacter.Health} / {GetEquippedStat(selectedCharacter.Health, equippedWeapon?.Health)}"); //  / {GetHoveredItemStat(selectedCharacter.Health, hoveredItem?.Health)} 추후 추가
                Console.SetCursorPosition(leftOffset, topOffset + 5);
                Console.WriteLine($"마나: {selectedCharacter.Mana} / {GetEquippedStat(selectedCharacter.Mana, equippedWeapon?.Mana)}");
                Console.SetCursorPosition(leftOffset, topOffset + 6);
                Console.WriteLine($"힘: {selectedCharacter.PhysicalAttack} / {GetEquippedStat(selectedCharacter.PhysicalAttack, equippedWeapon?.PhysicalAttack)}");
                Console.SetCursorPosition(leftOffset, topOffset + 7);
                Console.WriteLine($"지능: {selectedCharacter.MagicalAttack} / {GetEquippedStat(selectedCharacter.MagicalAttack, equippedWeapon?.MagicalAttack)}");
                Console.SetCursorPosition(leftOffset, topOffset + 8);
                Console.WriteLine($"물리 방어력: {selectedCharacter.PhysicalDefense} / {GetEquippedStat(selectedCharacter.PhysicalDefense, equippedWeapon?.PhysicalDefense)}");
                Console.SetCursorPosition(leftOffset, topOffset + 9);
                Console.WriteLine($"마법 방어력: {selectedCharacter.MagicalDefense} / {GetEquippedStat(selectedCharacter.MagicalDefense, equippedWeapon?.MagicalDefense)}");
                Console.SetCursorPosition(leftOffset, topOffset + 10);
                Console.WriteLine($"민첩: {selectedCharacter.Speed} / {GetEquippedStat(selectedCharacter.Speed, equippedWeapon?.Speed)}");
                Console.SetCursorPosition(leftOffset, topOffset + 11);
                Console.WriteLine($"정신력: {selectedCharacter.HealingPower} / {GetEquippedStat(selectedCharacter.HealingPower, equippedWeapon?.HealingPower)}");
                Console.SetCursorPosition(leftOffset, topOffset + 12);
                Console.WriteLine($"신앙: {selectedCharacter.SelfHealingPower} / {GetEquippedStat(selectedCharacter.SelfHealingPower, equippedWeapon?.SelfHealingPower)}");
                Console.SetCursorPosition(leftOffset, topOffset + 13);
                Console.WriteLine($"경험치: {selectedCharacter.Luck} / {GetEquippedStat(selectedCharacter.Luck, equippedWeapon?.Luck)}");
                Console.SetCursorPosition(leftOffset, topOffset + 14);
                Console.WriteLine($"경험치: {selectedCharacter.Critical} / {GetEquippedStat(selectedCharacter.Critical, equippedWeapon?.Critical)}");
            }
        }

        public void GameMenuFifthOnlyPlayerDisplay()
        {
            int topOffset = (Console.WindowHeight - Box.Menus.Count) / 2 - 6;
            int leftOffset = (Console.WindowWidth - Box.Width) / 2 + (65 - Box.Menus.Count);

            for (int i = 0; i < Box.Menus.Count; i++)
            {
                Console.SetCursorPosition(leftOffset, topOffset++);

                if (i == Box.SelectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(Box.Menus[i] + " ◀");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(Box.Menus[i]);
                }

                if (i < Box.Menus.Count - 1)
                {
                    Console.WriteLine();
                }
            }
        }

        private int GetEquippedStat(int baseStat, int? equippedStat)
        {
            return equippedStat.HasValue ? baseStat + equippedStat.Value : baseStat;
        }

        private int GetHoveredItemStat(int baseStat, int? hoveredStat)
        {
            return hoveredStat.HasValue ? baseStat + hoveredStat.Value : baseStat;
        }

      /*  private Weapon GetCurrentHoveredItem()
        {
            // 현재 커서가 가리키는 아이템 반환 로직
        }*/

        // 선택된 항목의 색상을 변경하고 커서를 숨깁니다.
        public void HighlightSelectedItem()
        {
            Console.SetCursorPosition(Box.SelectedItemLeftOffset, Box.SelectedItemTopOffset);
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.Write($"  {Box.Menus[Box.SelectedIndex]}  ");
            Console.ResetColor();

        }

        public void Navigate(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Box.PreviousItem();
                    break;
                case ConsoleKey.DownArrow:
                    Box.NextItem();
                    break;
                case ConsoleKey.LeftArrow:
                    Box.PreviousItem();
                    break;
                case ConsoleKey.RightArrow:
                    Box.NextItem();
                    break;
            }
        }
    }
}
