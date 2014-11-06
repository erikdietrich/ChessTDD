using System;
using System.Collections.Generic;
using System.Linq;

namespace Chess
{
    public class PathMaker
    {
        private readonly BoardCoordinate _origin;
        private readonly BoardCoordinate _destination;

        public PathMaker(BoardCoordinate origin, BoardCoordinate destination)
        {
            _origin = origin;
            _destination = destination;
        }

        public IEnumerable<BoardCoordinate> GetPathToDestination()
        {
            if (_origin.IsOnSameHorizontalPathAs(_destination))
                return GetHorizontalPathSpaces();
            else if (_origin.IsOnSameVerticalPathAs(_destination))
                return GetVerticalPathSpaces();
            else if(_origin.IsOnSameDiagonalPathAs(_destination))
                return GetDiagonalPathSpaces();

            return Enumerable.Empty<BoardCoordinate>();
        }

        private IEnumerable<BoardCoordinate> GetHorizontalPathSpaces()
        {
            var least = Math.Min(_origin.X, _destination.X);
            var most = Math.Max(_origin.X, _destination.X);
            var xCoordinatesToCheck = Enumerable.Range(least + 1, most - least);
            return xCoordinatesToCheck.Select(x => BoardCoordinate.For(x, _origin.Y));
        }

        private IEnumerable<BoardCoordinate> GetVerticalPathSpaces()
        {
            var least = Math.Min(_origin.Y, _destination.Y);
            var most = Math.Max(_origin.Y, _destination.Y);
            var yCoordinatesToCheck = Enumerable.Range(least + 1, most - least);
            return yCoordinatesToCheck.Select(y => BoardCoordinate.For(_origin.X, y));
        }

        private IEnumerable<BoardCoordinate> GetDiagonalPathSpaces()
        {
            var absoluteDistance = Math.Abs(_origin.X - _destination.X);
            var xDirection = (_destination.X - _origin.X) / absoluteDistance;
            var yDirection = (_destination.Y - _origin.Y) / absoluteDistance;
            return Enumerable.Range(1, absoluteDistance).Select(i => BoardCoordinate.For(_origin.X + i * xDirection, _origin.Y + i * yDirection));

        }
    }
}
