using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.GameEngine
{
    public class InputHandler
    {
        public enum MoveDir { Up, Down, Left, Right, Enter, C, Exit, None  }

        public MoveDir GetInput(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow: return MoveDir.Up;
                case ConsoleKey.DownArrow: return MoveDir.Down;
                case ConsoleKey.LeftArrow: return MoveDir.Left;
                case ConsoleKey.RightArrow: return MoveDir.Right;
                case ConsoleKey.Escape: return MoveDir.Exit;
                default: return MoveDir.None;
            }
        }
    }
}
