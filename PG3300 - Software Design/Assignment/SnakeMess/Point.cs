using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Point
    {
        #region Variables

        #endregion

        #region Properties
        public int X { get; set; }

        public int Y { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Create a point by inputting two integers
        /// </summary>
        public Point(int x = 0, int y = 0)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Create a point using another Point
        /// </summary>
        public Point(Point point)
        {
            this.X = point.X;
            this.Y = point.Y;
        }

        /// <summary>
        /// Get a sum of X multiplied by Y.
        /// </summary>
        public int MultipliedSum()
        {
            int result = X * Y;

            return result;
        }
        #endregion
    }
}
