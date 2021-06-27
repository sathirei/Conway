using GameOfLife.Core.Rules;
using GameOfLife.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Core
{
    public class Universe : IUniverse
    {
        private readonly IRule gameRule;

        public Universe(IRule gameRule, HashSet<ICell> initialSeed)
        {
            this.gameRule = gameRule ?? throw new ArgumentNullException("Game rule has to be set");
            this.LivingCells = initialSeed ?? throw new ArgumentNullException("Game should be seeded with life");
        }
        public HashSet<ICell> LivingCells { get; private set; }

        public IUniverse Evolve()
        {
            return new Universe(this.gameRule, GetNextGeneration());
        }

        private HashSet<ICell> GetNextGeneration()
        {
            return GetSurvivingCells().Concat(GetBornCells()).ToHashSet();
        }

        private HashSet<ICell> GetBornCells()
        {
            return this.LivingCells
                .SelectMany(livingCell => GetDeadNeighbours(livingCell))
                .Where(deadCell => this.gameRule.IsBorn(GetCountOfLivingNeighbours(deadCell)))
                .ToHashSet();
        }

        private HashSet<ICell> GetSurvivingCells()
        {
            return this.LivingCells
                .Where(livingCell => this.gameRule.DoesSurvive(GetCountOfLivingNeighbours(livingCell)))
                .ToHashSet();
        }

        private int GetCountOfLivingNeighbours(ICell gameCell)
        {
            return GetLivingNeighbours(gameCell).Count;
        }

        private HashSet<ICell> GetLivingNeighbours(ICell gameCell)
        {
            return gameCell.Neighbors.Intersect(this.LivingCells).ToHashSet();
        }

        private HashSet<ICell> GetDeadNeighbours(ICell gameCell)
        {
            return gameCell.Neighbors.Except(GetLivingNeighbours(gameCell)).ToHashSet();
        }
    }
}
