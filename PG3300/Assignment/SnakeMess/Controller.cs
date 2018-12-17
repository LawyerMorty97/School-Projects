using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Controller
    {
        #region Variables
        private GameField gamefield;

        #endregion

        #region Methods
        public Controller(GameField field)
        {
            gamefield = field;
        }
    
        public void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyList = Console.ReadKey(true);
                Direction lastDirection = gamefield.Player.LastDirection;

                if (keyList.Key == ConsoleKey.Escape)
                    gamefield.GameOver = true;
                else if (keyList.Key == ConsoleKey.Spacebar)
                {
                    gamefield.Pause = !gamefield.Pause;
                }
                else if (keyList.Key == ConsoleKey.UpArrow && lastDirection != Direction.Down)
                {
                    gamefield.Player.CurrentDirection = Direction.Up;
                }
                else if (keyList.Key == ConsoleKey.DownArrow && lastDirection != Direction.Up)
                {
                    gamefield.Player.CurrentDirection = Direction.Down;
                }
                else if (keyList.Key == ConsoleKey.LeftArrow && lastDirection != Direction.Right)
                {
                    gamefield.Player.CurrentDirection = Direction.Left;
                }
                else if (keyList.Key == ConsoleKey.RightArrow && lastDirection != Direction.Left)
                {
                    gamefield.Player.CurrentDirection = Direction.Right;
                }
            }
        }
        #endregion
    }
}
