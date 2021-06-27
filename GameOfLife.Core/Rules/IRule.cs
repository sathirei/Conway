namespace GameOfLife.Core.Rules
{
    public interface IRule
    {
        public bool DoesSurvive(int aliveNeighbours);
        public bool IsBorn(int aliveNeighbours);
    }
}
