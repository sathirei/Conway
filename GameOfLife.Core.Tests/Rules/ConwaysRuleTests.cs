using Xunit;
using FluentAssertions;

namespace GameOfLife.Core.Rules.Tests
{
    public class ConwaysRuleTests
    {
        [Theory()]
        [InlineData(2)]
        [InlineData(3)]
        public void DoesSurvive_Should_Be_True(int noOfLiveNeighbours)
        {
            // Arrange
            var conwaysRule = new ConwaysRule();

            // Act
            var result = conwaysRule.DoesSurvive(noOfLiveNeighbours);

            // Asserts
            result.Should().BeTrue();
        }

        [Theory()]
        [InlineData(1)]
        [InlineData(4)]
        public void DoesSurvive_Should_Be_False(int noOfLiveNeighbours)
        {
            // Arrange
            var conwaysRule = new ConwaysRule();

            // Act
            var result = conwaysRule.DoesSurvive(noOfLiveNeighbours);

            // Asserts
            result.Should().BeFalse();
        }

        [Fact()]
        public void IsBorn_Should_Be_True()
        {
            // Arrange
            var conwaysRule = new ConwaysRule();

            // Act
            var result = conwaysRule.IsBorn(3);

            // Asserts
            result.Should().BeTrue();
        }

        [Theory()]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void IsBorn_Should_Be_False(int noOfLiveNeighbours)
        {
            // Arrange
            var conwaysRule = new ConwaysRule();

            // Act
            var result = conwaysRule.IsBorn(noOfLiveNeighbours);

            // Asserts
            result.Should().BeFalse();
        }
    }
}