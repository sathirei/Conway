using GameOfLife.Domain;
using System.Collections.Generic;

namespace GameOfLife.Core.IO
{
    public interface IGameInputReader
    {
        public (int noOfEvolution, HashSet<ICell> lifeSeed) Read();
    }
}
