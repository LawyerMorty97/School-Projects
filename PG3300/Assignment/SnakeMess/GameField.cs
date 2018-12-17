using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace SnakeMess
{
    class GameField
    {
        #region Variables

        private readonly Stopwatch _gameTime;
        private readonly Random _randomGenerator;
        public Point App;
        public Settings GameSettings;
        #endregion

        #region Properties
        public Point Dimensions { get; }

        public bool GameOver { get; set; } = false;

        public bool Pause { get; set; } = false;

        public Player Player { get; set; }

        #endregion

        #region Methods
        /// <summary>
        /// Create an instance of the GameField object
        /// </summary>
        /// <param name="settings">The settings that will be used in the instance of the game session.</param>
        public GameField(Settings settings)
        {
            Dimensions = new Point(Console.WindowWidth, Console.WindowHeight);

            this._gameTime = new Stopwatch();
            this._gameTime.Start();

            this.App = new Point();
            this._randomGenerator = new Random();

            GameSettings = settings;
        }


        /// <summary>
        /// Handles the spawning of apples on the field.
        /// </summary>
        /// <param name="firstSpawn">Was the apple first spawned or not.</param>
        public void SpawnApple(bool firstSpawn = false)
        {
            while (true)
            {
                App.X = _randomGenerator.Next(0, Dimensions.X);
                App.Y = _randomGenerator.Next(0, Dimensions.Y);
                bool spot = true;

                foreach (Point part in Player.Body)
                {
                    if (part.X == App.X && part.Y == App.Y)
                    {
                        spot = false;
                        break;
                    }
                }

                if (spot)
                {
                    if (firstSpawn)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(App.X, App.Y);
                        Console.Write(GameSettings.Apple);
                    } else
                        Player.ExtendSnake = true;

                    break;
                }
            }
        }

        /// <summary>
        /// Updates the game field with the player
        /// </summary>
        public void Update()
        {
            if (Player == null) return;

            SpawnApple(true); // The Apple is spawned here for the first time
            while (!GameOver)
            {
                HandleInput();
                if (!Pause)
                {
                    if (_gameTime.ElapsedMilliseconds < 100)
                        continue;
                    _gameTime.Restart();

                    Player.Update();
                }
            }
        }

        /// <summary>
        /// Handles the input taken from the console.
        /// </summary>
        private void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyList = Console.ReadKey(true);
                Direction lastDirection = Player.LastDirection;

                if (keyList.Key == ConsoleKey.Escape)
                    GameOver = true;
                else if (keyList.Key == ConsoleKey.Spacebar)
                {
                    Pause = !Pause;
                }
                else if (keyList.Key == ConsoleKey.UpArrow && lastDirection != Direction.Down)
                {
                    Player.CurrentDirection = Direction.Up;
                }
                else if (keyList.Key == ConsoleKey.DownArrow && lastDirection != Direction.Up)
                {
                   Player.CurrentDirection = Direction.Down;
                }
                else if (keyList.Key == ConsoleKey.LeftArrow && lastDirection != Direction.Right)
                {
                    Player.CurrentDirection = Direction.Left;
                }
                else if (keyList.Key == ConsoleKey.RightArrow && lastDirection != Direction.Left)
                {
                    Player.CurrentDirection = Direction.Right;
                }
            }
        }
#endregion
    }
}
