using GameOfLife.Core;
using GameOfLife.Core.IO;
using GameOfLife.Core.Rules;

namespace GameOfLife.App
{
    public class GameOfLife
    {
        private readonly IGameInputReader gameInputReader;
        private readonly IRule gameRule;
        private readonly IGameOutputWriter gameOutputWriter;

        public GameOfLife(IGameInputReader gameInputReader,  IRule gameRule, IGameOutputWriter gameOutputWriter)
        {
            this.gameInputReader = gameInputReader;
            this.gameRule = gameRule;
            this.gameOutputWriter = gameOutputWriter;
        }

        public void Run() 
        {
            var (noOfEvolutions, lifeSeed) = gameInputReader.Read();
            IUniverse universe = new Universe(gameRule, lifeSeed);
            for(var i = 0; i < noOfEvolutions; i++)
            {
                //gameOutputWriter.Write(@void); // un-comment this if you want to display the @void after every run
                universe.Evolve();
            }
            gameOutputWriter.Write(universe);
        }
    }
}
