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

        public abstract IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate startingLocation, int boardSize = Board.DefaultBoardSize);

        public virtual bool IsCaptureAllowed(BoardCoordinate origin, BoardCoordinate destination)
        {
            return GetMovesFrom(origin).Any(m => m.Matches(destination));
        }

        public virtual bool IsNonCaptureAllowed(BoardCoordinate origin, BoardCoordinate destination)
        {
            return true;
        }

        protected static IEnumerable<BoardCoordinate> GetAllRadialMovesFrom(BoardCoordinate startingLocation, int distance)
        {
            return GetRadialDiagonalFromInclusive(startingLocation, distance).Union(GetRadialAdjecentFromInclusive(startingLocation, distance));
        }

        protected static IEnumerable<BoardCoordinate> GetRadialDiagonalFromInclusive(BoardCoordinate startingPosition, int distance)
        {
            var squaresToRadiate = Enumerable.Range(1, distance);
            return squaresToRadiate.SelectMany(sq => GetRadialDiagonalFrom(startingPosition, sq));
        }

        protected static IEnumerable<BoardCoordinate> GetRadialDiagonalFrom(BoardCoordinate startingPosition, int distance)
        {
            yield return new BoardCoordinate(startingPosition.X + distance, startingPosition.Y + distance);
            yield return new BoardCoordinate(startingPosition.X + distance, startingPosition.Y - distance);
            yield return new BoardCoordinate(startingPosition.X - distance, startingPosition.Y + distance);
            yield return new BoardCoordinate(startingPosition.X - distance, startingPosition.Y - distance);
        }

        protected static IEnumerable<BoardCoordinate> GetRadialAdjecentFromInclusive(BoardCoordinate startingPosition, int distance)
        {
            var squaresToRadiate = Enumerable.Range(1, distance);
            return squaresToRadiate.SelectMany(sq => GetRadialAdjacentFrom(startingPosition, sq));
        }

        protected static IEnumerable<BoardCoordinate> GetRadialAdjacentFrom(BoardCoordinate startingPosition, int distance)
        {
            yield return new BoardCoordinate(startingPosition.X + distance, startingPosition.Y);
            yield return new BoardCoordinate(startingPosition.X - distance, startingPosition.Y);
            yield return new BoardCoordinate(startingPosition.X, startingPosition.Y + distance);
            yield return new BoardCoordinate(startingPosition.X, startingPosition.Y - distance);
        }
    }
}
