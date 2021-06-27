﻿using System.Collections.Generic;

namespace GameOfLife.Core.Rules
{
    public class ConwaysRule : GameRule
    {
        public ConwaysRule()
            : base(
                  nosOfNeighboursForSurvival: new HashSet<int> { 2, 3 },
                  noOfLiveNeighboursForBirth: 3)
        {
        }
    }
}
