using GameOfLife.Domain;
using System.Collections.Generic;

namespace GameOfLife.Core
{
    public interface IUniverse
    {
        public HashSet<ICell> LivingCells { get; }
        public void Evolve();
    }
}
