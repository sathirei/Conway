using System;
using System.Linq;
using System.Text;

namespace GameOfLife.Core.IO
{
    public class ConsoleGameOutputWriter : IGameOutputWriter
    {
        public void Write(IUniverse universe)
        {
            Console.WriteLine(Format(universe));
        }

        private static string Format(IUniverse universe)
        {
            var sortedLivingCells = universe.LivingCells
                .OrderBy(x => x.Point.XPosition)
                .ThenBy(y => y.Point.YPosition)
                .Select(x => x.ToString());
            var sb = new StringBuilder();
            sb.Append("[");
            sb.Append(string.Join(", ", sortedLivingCells));
            sb.Append("]");
            return sb.ToString();
        }
    }
}
