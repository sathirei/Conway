using GameOfLife.Core.Exception;
using GameOfLife.Domain;
using System;
using System.Collections.Generic;
using System.IO;

namespace GameOfLife.Core.IO
{
    public class FileGameInputReader : IGameInputReader
    {
        private readonly string filePath;

        public FileGameInputReader(string filePath)
        {
            this.filePath = filePath ?? throw new ArgumentNullException("Input file path for game should be provided");
        }
        public (int noOfEvolution, HashSet<ICell> lifeSeed) Read()
        {
            var fullPath = Path.GetFullPath(filePath);
            using StreamReader file = new StreamReader(fullPath);
            string line = default;
            int counter = 0;
            int noOfEvolution = 0;
            var lifeSeed = new HashSet<ICell>();
            try
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        throw new ArgumentException("Input file is invalid. Please correct the input and try again.");
                    }
                    if (counter == 0)
                    {
                        noOfEvolution = int.Parse(line);
                    }
                    else
                    {
                        lifeSeed.Add(GetCell(line));
                    }
                    counter++;
                }
            }
            catch(System.Exception ex)
            {
                // log error before throwing it
                throw new InvalidInputException($"Unable to parse the game input. Error: {ex.Message}, Input Line No: {counter}, Line Details: {line}");
            }
            return (noOfEvolution, lifeSeed);
        }

        private ICell GetCell(string line)
        {
            var values = line.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            return new GameCell(new Point(int.Parse(values[0]), int.Parse(values[1])));
        }
    }
}
