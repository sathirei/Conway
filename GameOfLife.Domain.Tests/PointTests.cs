using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Domain.Tests
{
    public class PointTests
    {
        [Fact()]
        public void Equals_Should_BeTrue()
        {
            // Arrange
            var firstPoint = new Point(1, 2);
            var secondPoint = new Point(1, 2);

            // Act            
            var result = firstPoint.Equals(secondPoint);

            // Asserts
            result.Should().BeTrue();
        }

        [Fact()]
        public void Equals_Should_BeFalse()
        {
            // Arrange
            var firstPoint = new Point(1, 2);
            var secondPoint = new Point(1, 3);

            // Act            
            var result = firstPoint.Equals(secondPoint);

            // Asserts
            result.Should().BeFalse();
        }

        [Fact()]
        public void Equals_Should_BeFalse_WhenGameCellToCompare_IsNull()
        {
            // Arrange
            var point = new Point(1, 2);

            // Act            
            var result = point.Equals(null);

            // Asserts
            result.Should().BeFalse();
        }

        [Fact()]
        public void ToString_Should_Be_AsExpected()
        {
            // Arrange
            var point = new Point(1, 2);

            // Act            
            var result = point.ToString();

            // Asserts
            result.Should().Be("(1,2)");
        }

        [Fact()]
        public void HashSet_Should_Not_Result_InDuplicatePoint()
        {
            // Arrange
            var point = new Point(1, 2);
            var duplicatePoint = new Point(1, 2);


            // Act            
            var pointSet = new HashSet<Point>
            {
                point,
                duplicatePoint
            };

            // Asserts
            pointSet.Should().HaveCount(1);
            pointSet.Single().Should().Be(point);
        }
    }
}