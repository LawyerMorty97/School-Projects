using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace SnakeMess
{
    #region Namespace Datatypes
    /// <summary>
    /// Enumerator used to control direction of an entity
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// Facing Up
        /// </summary>
        Up = 0,
        /// <summary>
        /// Facing Down
        /// </summary>
        Down = 2,
        /// <summary>
        /// Facing Left
        /// </summary>
        Left = 3,
        /// <summary>
        /// Facing Right
        /// </summary>
        Right = 1
    }

    /// <summary>
    /// A data structure holding the settings of the game.
    /// </summary>
    public struct Settings
    {
        /// <summary>
        /// The string for an apple
        /// </summary>
        public string Apple;
        /// <summary>
        /// The string for the head of the snake
        /// </summary>
        public string SnakeHead;
        /// <summary>
        /// The string for the body of the snake
        /// </summary>
        public string SnakeBody;
    }
    #endregion

    class Client
    {
        #region Variables
        private static GameField _board;
        private static Player _player;

        static Settings _gameSettings;
        #endregion

        #region Methods
        /// <summary>
        /// Create an instance of the whole game (GameField and a Player class).
        /// </summary>
        public void Init()
        {
            _gameSettings.Apple = "$";
            _gameSettings.SnakeBody = "0";
            _gameSettings.SnakeHead = "@";

            Console.CursorVisible = false;
            Console.Title = "Høyskolen Kristiania - SNAKE";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 10);
            Console.Write("@");

            _board = new GameField(_gameSettings);
            _player = new Player(_board);

            _board.Player = _player; // Player Instance Property
            _board.Update();
        }

        
        #endregion
    }
}