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

        public bool IsCoordinateValidForBoardSize(int boardSize)
        {
            return IsDimensionValidForBoardSize(X, boardSize) && IsDimensionValidForBoardSize(Y, boardSize);
        }

        public bool IsOnSameVerticalPathAs(BoardCoordinate other)
        {
            return _x == other.X;
        }

        public bool IsOnSameHorizontalPathAs(BoardCoordinate other)
        {
            return _y == other.Y;
        }

        public bool IsOnSameDiagonalPathAs(BoardCoordinate other)
        {
            return Math.Abs(_x - other.X) == Math.Abs(_y - other.Y);
        }

        public bool Matches(int x, int y)
        {
            return _x == x && _y == y;
        }

        public bool Matches(BoardCoordinate destination)
        {
            return Matches(destination.X, destination.Y);
        }

        private static bool IsDimensionValidForBoardSize(int dimensionValue, int boardSize)
        {
            return dimensionValue > 0 && dimensionValue <= boardSize;
        }
    }
}
