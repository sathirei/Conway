using System;
using System.Collections.Generic;

namespace GameOfLife.Domain
{
    public class GameCell : ICell
    {
        public GameCell(Point point)
        {
            this.Point = point;
        }

        public Point Point { get; }

        public HashSet<ICell> Neighbors => new HashSet<ICell>
            {
                // top left
                new GameCell(new Point(this.Point.XPosition - 1, this.Point.YPosition + 1)),
                // above
                new GameCell(new Point(this.Point.XPosition, this.Point.YPosition + 1)),
                // top right
                new GameCell(new Point(this.Point.XPosition + 1, this.Point.YPosition + 1)),
                // left
                new GameCell(new Point(this.Point.XPosition - 1, this.Point.YPosition)),
                // right
                new GameCell(new Point(this.Point.XPosition + 1, this.Point.YPosition)),
                // bottom left
                new GameCell(new Point(this.Point.XPosition - 1, this.Point.YPosition - 1)),
                // below
                new GameCell(new Point(this.Point.XPosition, this.Point.YPosition - 1)),
                // bottom right
                new GameCell(new Point(this.Point.XPosition + 1, this.Point.YPosition - 1))

            };

        public override string ToString()
        {
            return this.Point.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            var to = obj as ICell;
            return this.Point.Equals(to.Point);

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Point);
        }
    }
}
