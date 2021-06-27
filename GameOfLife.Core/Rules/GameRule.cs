using System.Collections.Generic;

namespace GameOfLife.Core.Rules
{
    public abstract class GameRule : IRule
    {
        private readonly HashSet<int> nosOfNeighboursForSurvival;
        private readonly int noOfLiveNeighboursForBirth;

        public GameRule(HashSet<int> nosOfNeighboursForSurvival, int noOfLiveNeighboursForBirth)
        {
            this.nosOfNeighboursForSurvival = nosOfNeighboursForSurvival;
            this.noOfLiveNeighboursForBirth = noOfLiveNeighboursForBirth;
        }
        public bool IsBorn(int aliveNeighbours)
        {
            return aliveNeighbours == noOfLiveNeighboursForBirth;
        }

        public bool DoesSurvive(int aliveNeighbours)
        {
            return nosOfNeighboursForSurvival.Contains(aliveNeighbours);
        }
    }
}
