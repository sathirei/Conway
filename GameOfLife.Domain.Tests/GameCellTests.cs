using Xunit;
using FluentAssertions;

namespace GameOfLife.Domain.Tests
{
    public class GameCellTests
    {
        [Fact()]
        public void GameCell_Should_Initialize_Successfully()
        {
            // Arrange
            var point = new Point(1, 2);

            // Act                        
            var gameCell = new GameCell(point);

            // Asserts
            gameCell.Point.Should().Be(point);
            gameCell.Neighbors.Should().NotBeNullOrEmpty();
        }

        [Fact()]
        public void Neighbors_Should_Be_AsExpected()
        {
            // Arrange
            var firstCell = new GameCell(new Point(1, 2));

            // Act            
            var result = firstCell.Neighbors;

            // Asserts
            result.Should().HaveCount(6);
            result.Contains(new Point(0, 3));
            result.Contains(new Point(1, 3));
            result.Contains(new Point(2, 3));
            result.Contains(new Point(0, 1));
            result.Contains(new Point(0, 3));
            result.Contains(new Point(0, 1));
            result.Contains(new Point(1, 1));
            result.Contains(new Point(2, 1));
        }
    }
}