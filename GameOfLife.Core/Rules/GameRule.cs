using System.Collections.Generic;

namespace GameOfLife.Core.Rules
{
    public abstract class GameRule : IRule
    {
        private readonly HashSet<int> nosOfLiveNeighboursForSurvival;
        private readonly int noOfLiveNeighboursForBirth;

        public GameRule(HashSet<int> nosOfLiveNeighboursForSurvival, int noOfLiveNeighboursForBirth)
        {
            this.nosOfLiveNeighboursForSurvival = nosOfLiveNeighboursForSurvival;
            this.noOfLiveNeighboursForBirth = noOfLiveNeighboursForBirth;
        }
        public bool IsBorn(int aliveNeighbours)
        {
            return aliveNeighbours == noOfLiveNeighboursForBirth;
        }

        public bool DoesSurvive(int aliveNeighbours)
        {
            return nosOfLiveNeighboursForSurvival.Contains(aliveNeighbours);
        }
    }
}
