using System.Collections.Generic;

namespace GameOfLife.Domain
{
    public interface ICell
    {
        public HashSet<ICell> Neighbors { get; }
        public Point Point { get; }
    }
}
