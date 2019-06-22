using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Player
    {
        #region Variables

        private readonly GameField _field;
        #endregion

        #region Properties
        public bool ExtendSnake { get; set; } = false;

        public Direction CurrentDirection { get; set; } = Direction.Down;

        public Direction LastDirection { get; set; }

        public List<Point> Body { get; set; }

        #endregion

        #region Methods
        /// <summary>
        /// Create an instance of the Player object
        /// </summary>
        /// <param name="field">The game field where the player will be placed</param>
        public Player(GameField field)
        {
            this._field = field;
            Body = new List<Point>();

            // Start off the body with 4 rings
            for (int i = 0; i < 4; i++)
            {
                Body.Add(new Point(10, 10));
            }
        }

        /// <summary>
        /// Handles the logic related to when the player is killed by different actions
        /// </summary>
        /// <param name="playerHead">The point where the head of the snake is</param>
        private void Logic_Death(Point playerHead)
        {
            // Going over any edge of the screen = Game Over
            if (playerHead.X < 0 || playerHead.X >= _field.Dimensions.X)
                _field.GameOver = true;
            else if (playerHead.Y < 0 || playerHead.Y >= _field.Dimensions.Y)
                _field.GameOver = true;

            // 
            if ((Body.Count + 1) >= _field.App.MultipliedSum())
                _field.GameOver = true;

            // Eating yourself = Die
            foreach (Point part in Body)
            {
                if (part.X == playerHead.X && part.Y == playerHead.Y)
                {
                    _field.GameOver = true;
                    break;
                }
            }
        }

        /// <summary>
        /// Handles updating the body of the player and all related calls to player death.
        /// </summary>
        public void Update()
        {
            Point tail = new Point(Body.First());
            Point head = new Point(Body.Last());
            Point newHead = new Point(head);

            switch (CurrentDirection)
            {
                case Direction.Up:
                    newHead.Y -= 1;
                    break;
                case Direction.Down:
                    newHead.Y += 1;
                    break;
                case Direction.Left:
                    newHead.X -= 1;
                    break;
                case Direction.Right:
                    newHead.X += 1;
                    break;
                default:
                    newHead.X += 1;
                    break;
            }
            // her og i controller
            Logic_Death(newHead); // Handle Death

            // Eat apples
            if (newHead.X == _field.App.X && newHead.Y == _field.App.Y)
            {
                _field.SpawnApple();
            }

            // Prevent Cannibalism
            if (!ExtendSnake)
            {
                Body.RemoveAt(0);
            }

            if (!_field.GameOver)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(head.X, head.Y);
                Console.Write(_field.GameSettings.SnakeBody);

                if (!ExtendSnake)
                {
                    Console.SetCursorPosition(tail.X, tail.Y);
                    Console.Write(" ");
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(_field.App.X, _field.App.Y);
                    Console.Write(_field.GameSettings.Apple);
                    ExtendSnake = false;
                }

                Body.Add(newHead);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(newHead.X, newHead.Y);
                Console.Write(_field.GameSettings.SnakeHead);
            }

            LastDirection = CurrentDirection;
        }
        #endregion
    }
}
