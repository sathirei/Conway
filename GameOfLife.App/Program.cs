using GameOfLife.Core.IO;
using GameOfLife.Core.Rules;
using System;

namespace GameOfLife.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameInputReader = new FileGameInputReader("./gameinput.txt");
            var gameOutputWriter = new ConsoleGameOutputWriter();
            var conwaysRule = new ConwaysRule();
            var conwaysGameOfLife = new GameOfLife(gameInputReader, conwaysRule, gameOutputWriter);
            conwaysGameOfLife.Run();
            Console.ReadKey();
        }
    }
}
