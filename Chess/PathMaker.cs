using System;
using System.Collections.Generic;
using System.Linq;

using static System.Linq.Enumerable;

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

            return Empty<BoardCoordinate>();
        }

        private IEnumerable<BoardCoordinate> GetHorizontalPathSpaces()
        {
            if (_origin.X < _destination.X)
            {
                var xCoordinatesToCheck = Range(_origin.X + 1, _destination.X - _origin.X);
                return xCoordinatesToCheck.Select(x => BoardCoordinate.For(x, _origin.Y));
            }
            else if(_origin.X > _destination.X)
            {
                var xCoordinatesToCheck = Range(_destination.X, _origin.X - _destination.X).Reverse();
                return xCoordinatesToCheck.Select(x => BoardCoordinate.For(x, _origin.Y));
            }
            return Empty<BoardCoordinate>();
        }

        private IEnumerable<BoardCoordinate> GetVerticalPathSpaces()
        {
            if (_origin.Y < _destination.Y)
            {
                var yCoordinatesToCheck = Range(_origin.Y + 1, _destination.Y - _origin.Y);
                return yCoordinatesToCheck.Select(y => BoardCoordinate.For(_origin.X, y));
            }
            else
            {
                var yCoordinatesToCheck = Range(_destination.Y, _origin.Y - _destination.Y).Reverse();
                return yCoordinatesToCheck.Select(y => BoardCoordinate.For(_origin.X, y));
            }
        }

        private IEnumerable<BoardCoordinate> GetDiagonalPathSpaces()
        {
            var absoluteDistance = Math.Abs(_origin.X - _destination.X);
            var xDirection = (_destination.X - _origin.X) / absoluteDistance;
            var yDirection = (_destination.Y - _origin.Y) / absoluteDistance;
            return Range(1, absoluteDistance).Select(i => BoardCoordinate.For(_origin.X + i * xDirection, _origin.Y + i * yDirection));
        }
    }
}
