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

        private bool DoesSquareAttack(BoardCoordinate attackingCoordinate, BoardCoordinate victimCoordinate, bool isFirstPlayerAttacking)
        {
            var attacker = _board.GetPiece(attackingCoordinate);

            return attacker != null && _board.IsMoveLegal(attackingCoordinate, victimCoordinate) && 
                attacker.IsCaptureAllowed(attackingCoordinate, victimCoordinate) && 
                isFirstPlayerAttacking != attacker.IsFirstPlayerPiece;
        }

    }
}
