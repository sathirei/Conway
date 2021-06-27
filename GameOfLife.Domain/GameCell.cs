using System.Collections.Generic;

namespace GameOfLife.Domain
{
    public class GameCell : ICell
    {
        public GameCell(Point point)
        {
            this.Point = point;
        }

        public Point Point { get; private set; }

        public HashSet<Point> Neighbors => new HashSet<Point>
            {
                // top left
                new Point(this.Point.XPosition - 1, this.Point.YPosition + 1),
                // above
                new Point(this.Point.XPosition, this.Point.YPosition + 1),
                // top right
                new Point(this.Point.XPosition + 1, this.Point.YPosition + 1),
                // left
                new Point(this.Point.XPosition - 1, this.Point.YPosition),
                // right
                new Point(this.Point.XPosition + 1, this.Point.YPosition),
                // bottom left
                new Point(this.Point.XPosition - 1, this.Point.YPosition - 1),
                // bottom right
                new Point(this.Point.XPosition - 1, this.Point.YPosition + 1)
            };
    }
}
