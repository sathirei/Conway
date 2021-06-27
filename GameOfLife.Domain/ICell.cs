using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Domain
{
    interface ICell
    {
        public List<ICell> Neighbors { get; set; }
    }
}
