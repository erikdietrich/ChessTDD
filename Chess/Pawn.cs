using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class Pawn : Piece
    {

        public Pawn(bool isFirstPlayerPiece = true) : base(isFirstPlayerPiece)
        { }

        public override IEnumerable<BoardCoordinate> GetMovesFrom(BoardCoordinate startingLocation, int boardSize = Board.DefaultBoardSize)
        {
            yield return new BoardCoordinate(startingLocation.X, startingLocation.Y + 1);
            if(!HasMoved)
                yield return new BoardCoordinate(startingLocation.X, startingLocation.Y + 2);
            yield return new BoardCoordinate(startingLocation.X + 1, startingLocation.Y + 1);
            yield return new BoardCoordinate(startingLocation.X - 1, startingLocation.Y + 1);
        }

        public override bool IsCaptureAllowed(BoardCoordinate origin, BoardCoordinate destination)
        {
            return IsOverOne(origin, destination) && IsUpOne(origin, destination);
        }

        public override bool IsNonCaptureAllowed(BoardCoordinate origin, BoardCoordinate destination)
        {
            return !(origin.X + 1 == destination.X && origin.Y + 1 == destination.Y);
        }

        private static bool IsOverOne(BoardCoordinate origin, BoardCoordinate destination)
        {
            return origin.X + 1 == destination.X || origin.X - 1 == destination.X;
        }
        private static bool IsUpOne(BoardCoordinate origin, BoardCoordinate destination)
        {
            return origin.Y + 1 == destination.Y;
        }
    }
}
