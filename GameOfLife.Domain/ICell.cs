using System.Collections.Generic;

namespace GameOfLife.Domain
{
    public interface ICell
    {
        public HashSet<Point> Neighbors { get; }
        public Point Point { get; }
    }
}
