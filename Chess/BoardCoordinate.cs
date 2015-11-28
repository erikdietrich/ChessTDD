using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public struct BoardCoordinate
    {
        private readonly int _x;
        public int X { get { return _x; } }

        private readonly int _y;
        public int Y { get { return _y; } }

        public BoardCoordinate(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public static BoardCoordinate For(int x, int y)
        {
            return new BoardCoordinate(x, y);
        }

    }
}
