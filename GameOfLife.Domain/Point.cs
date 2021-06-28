using System;

namespace GameOfLife.Domain
{
    public class Point
    {
        public Point(int xPosition, int yPosition)
        {
            this.XPosition = xPosition;
            this.YPosition = yPosition;
        }
        public int XPosition { get; }
        public int YPosition { get; }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            var to = obj as Point;
            return this.XPosition == to.XPosition && this.YPosition == to.YPosition;

        }

        public override int GetHashCode()
        {
            return HashCode.Combine(XPosition, YPosition);
        }

        public override string ToString()
        {
            return $"({this.XPosition},{this.YPosition})";
        }
    }
}
