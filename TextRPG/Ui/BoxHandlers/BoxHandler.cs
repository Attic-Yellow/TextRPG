using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Ui.BoxHandlers
{
    public class Box
    {
        public List<string> Menus { get; set; }
        public int SelectedIndex { get; private set; } = 0;
        public int Width { get; set; } = 40;
        public int Padding { get; set; } = 2;

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

        public BoxHandler(List<string> menuNumbers, int width = 40)
        {
            Box = new Box(menuNumbers) { Width = width };
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
            }
        }
    }
}
