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
            if (IsFirstPlayerPiece)
            {
                yield return new BoardCoordinate(startingLocation.X, startingLocation.Y + 1);
                if (!HasMoved)
                    yield return new BoardCoordinate(startingLocation.X, startingLocation.Y + 2);
                yield return new BoardCoordinate(startingLocation.X + 1, startingLocation.Y + 1);
                yield return new BoardCoordinate(startingLocation.X - 1, startingLocation.Y + 1);
            }
            else
            {
                yield return new BoardCoordinate(startingLocation.X, startingLocation.Y - 1);
                yield return new BoardCoordinate(startingLocation.X, startingLocation.Y - 2);
            }
        }

        public override bool IsCaptureAllowed(BoardCoordinate origin, BoardCoordinate destination)
        {
            return GetRadialDiagonalFrom(origin, 1).Any(d => d.Matches(destination));
        }

        public override bool IsNonCaptureAllowed(BoardCoordinate origin, BoardCoordinate destination)
        {
            if (IsFirstPlayerPiece)
            {
                if (HasMoved)
                    return IsVerticalMoveBy(1, origin, destination);
                else
                    return IsVerticalMoveBy(1, origin, destination) || IsVerticalMoveBy(2, origin, destination);
            }
            else
            {
               return IsVerticalMoveBy(-1, origin, destination) || IsVerticalMoveBy(-2, origin, destination);
            }
        }

        private static bool IsVerticalMoveBy(int verticalSpaces, BoardCoordinate origin, BoardCoordinate destination)
        {
            return origin.Y + verticalSpaces == destination.Y && origin.X == destination.X;
        }
    }
}
