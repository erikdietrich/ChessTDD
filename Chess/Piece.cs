using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public abstract class Piece
    {
        public bool IsFirstPlayerPiece { get; private set; }

        public bool HasMoved { get; set; }
        
        public Piece(bool isFirstPlayerPiece = true)
        {
            IsFirstPlayerPiece = isFirstPlayerPiece;
        }

        public abstract IEnumerable<int[]> GetMovesFrom(int startingLocationX, int startingLocationY, int boardSize = Board.DefaultBoardSize);

        public virtual bool IsCaptureAllowed(int originX, int originY, int destinationX, int destinationY)
        {
            return true;
        }

        public virtual bool IsNonCaptureAllowed(int originX, int originY, int destinationX, int destinationY)
        {
            return true;
        }

        protected static IEnumerable<int[]> GetAllRadialMovesFrom(int x, int y, int distance)
        {
            return GetRadialDiagonalFromInclusive(x, y, distance).Union(GetRadialAdjecentFromInclusive(x, y, distance));
        }

        protected static IEnumerable<int[]> GetRadialDiagonalFromInclusive(int x, int y, int distance)
        {
            var squaresToRadiate = Enumerable.Range(1, distance);
            return squaresToRadiate.SelectMany(sq => GetRadialDiagonalFrom(x, y, sq));
        }

        protected static IEnumerable<int[]> GetRadialDiagonalFrom(int x, int y, int distance)
        {
            yield return new int[] { x + distance, y + distance };
            yield return new int[] { x + distance, y - distance };
            yield return new int[] { x - distance, y + distance };
            yield return new int[] { x - distance, y - distance };
        }

        protected static IEnumerable<int[]> GetRadialAdjecentFromInclusive(int x, int y, int distance)
        {
            var squaresToRadiate = Enumerable.Range(1, distance);
            return squaresToRadiate.SelectMany(sq => GetRadialAdjacentFrom(x, y, sq));
        }

        protected static IEnumerable<int[]> GetRadialAdjacentFrom(int x, int y, int distance)
        {
            yield return new int[] { x + distance, y };
            yield return new int[] { x - distance, y };
            yield return new int[] { x, y + distance };
            yield return new int[] { x, y - distance };
        }
    }
}
