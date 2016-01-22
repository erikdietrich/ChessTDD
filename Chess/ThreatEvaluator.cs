using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class ThreatEvaluator
    {
        private readonly Board _board;

        public ThreatEvaluator(Board board)
        {
            _board = board;
        }

        public bool IsThreatened(BoardCoordinate victim, bool isFirstPlayerAttacking)
        {
            var numbers = Enumerable.Range(1, _board.Size);

            var coordinates = numbers.SelectMany(x => numbers, (x, y) => BoardCoordinate.For(x, y));

            return coordinates.Any(c => DoesSquareAttack(c, victim, isFirstPlayerAttacking));
        }

        private bool DoesSquareAttack(BoardCoordinate attacker, BoardCoordinate victim, bool isFirstPlayerAttacking)
        {
            var piece = _board.GetPiece(attacker);

            return piece != null && piece.IsCaptureAllowed(attacker, victim) && isFirstPlayerAttacking != piece.IsFirstPlayerPiece;
        }

    }
}
