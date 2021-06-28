using GameOfLife.Core.IO;
using GameOfLife.Core.Rules;
using static System.Console;

namespace GameOfLife.App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IGameInputReader gameInputReader = new FileGameInputReader("./gameinput.txt");
            IGameOutputWriter gameOutputWriter = new ConsoleGameOutputWriter();
            IRule conwaysRule = new ConwaysRule();
            GameOfLife conwaysGameOfLife = new GameOfLife(gameInputReader, conwaysRule, gameOutputWriter);
            conwaysGameOfLife.Run();
            ReadKey();
        }
    }
}
