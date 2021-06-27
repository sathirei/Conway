using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;

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
            result.Should().HaveCount(8);
            result.Contains(new GameCell(new Point(0, 3)));
            result.Contains(new GameCell(new Point(1, 3)));
            result.Contains(new GameCell(new Point(2, 3)));
            result.Contains(new GameCell(new Point(1, 1)));
            result.Contains(new GameCell(new Point(1, 3)));
            result.Contains(new GameCell(new Point(0, 1)));
            result.Contains(new GameCell(new Point(1, 1)));
            result.Contains(new GameCell(new Point(2, 1)));
        }

        [Fact()]
        public void Equals_Should_BeTrue()
        {
            // Arrange
            var firstCell = new GameCell(new Point(1, 2));
            var secondCell = new GameCell(new Point(1, 2));

            // Act            
            var result = firstCell.Equals(secondCell);

            // Asserts
            result.Should().BeTrue();
        }

        [Fact()]
        public void Equals_Should_BeFalse()
        {
            // Arrange
            var firstCell = new GameCell(new Point(1, 2));
            var secondCell = new GameCell(new Point(1, 3));

            // Act            
            var result = firstCell.Equals(secondCell);

            // Asserts
            result.Should().BeFalse();
        }

        [Fact()]
        public void Equals_Should_BeFalse_WhenGameCellToCompare_IsNull()
        {
            // Arrange
            var gameCell = new GameCell(new Point(1, 2));

            // Act            
            var result = gameCell.Equals(null);

            // Asserts
            result.Should().BeFalse();
        }

        [Fact()]
        public void ToString_Should_Be_AsExpected()
        {
            // Arrange
            var gameCell = new GameCell(new Point(1, 2));

            // Act            
            var result = gameCell.ToString();

            // Asserts
            result.Should().Be("(1, 2)");
        }

        [Fact()]
        public void HashSet_Should_Not_Result_InDuplicatePoint()
        {
            // Arrange
            var gameCell = new GameCell(new Point(1, 2));
            var duplicateGameCell = new GameCell(new Point(1, 2));


            // Act            
            var gameCellSet = new HashSet<ICell>
            {
                gameCell,
                duplicateGameCell
            };

            // Asserts
            gameCellSet.Should().HaveCount(1);
            gameCellSet.Single().Should().Be(gameCell);
        }
    }
}