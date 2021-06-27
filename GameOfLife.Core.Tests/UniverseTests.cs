using Xunit;
using System.Collections.Generic;
using GameOfLife.Core.Rules;
using Moq;
using GameOfLife.Domain;
using FluentAssertions;
using System.Linq;

namespace GameOfLife.Core.Tests
{
    public class UniverseTests
    {
        [Fact()]
        public void Universe_Should_Initialize_Successfully()
        {
            // Arrange
            var mockRule = new Mock<IRule>();
            var lifeSeed = new HashSet<ICell> { new GameCell(new Point(1, 2)) };

            // Act
            var sut = new Universe(mockRule.Object, lifeSeed);

            // Asserts
            sut.LivingCells.Should().BeEquivalentTo(lifeSeed);
            mockRule.Verify(x => x.DoesSurvive(It.IsAny<int>()), Times.Never);
            mockRule.Verify(x => x.IsBorn(It.IsAny<int>()), Times.Never);
        }

        [Fact()]
        public void Evolve_Should_Return_A_New_Universe()
        {
            // Arrange
            var mockRule = new Mock<IRule>();
            var lifeSeed = new HashSet<ICell> { new GameCell(new Point(1, 2)) };

            // Act
            var sut = new Universe(mockRule.Object, lifeSeed);
            var evolvedUniverse = sut.Evolve();

            // Asserts
            evolvedUniverse.Should().NotBeEquivalentTo(sut);
            mockRule.Verify(x => x.DoesSurvive(It.IsAny<int>()), Times.AtLeastOnce);
            mockRule.Verify(x => x.IsBorn(It.IsAny<int>()), Times.AtLeastOnce);
        }

        [Fact()]
        public void Evolve_OneTime_Should_Be_As_Expected()
        {
            // Arrange
            var mockRule = new Mock<IRule>();
            var lifeSeed = new HashSet<ICell> { new GameCell(new Point(1, 2)) };
            mockRule.Setup(x => x.IsBorn(It.IsAny<int>())).Returns(false);
            mockRule.Setup(x => x.DoesSurvive(It.IsAny<int>())).Returns(false);

            // Act
            var sut = new Universe(mockRule.Object, lifeSeed);
            var evolvedUniverse = sut.Evolve();

            // Asserts
            evolvedUniverse.Should().NotBeEquivalentTo(sut);
            evolvedUniverse.LivingCells.Should().BeEmpty();
            mockRule.Verify(x => x.DoesSurvive(It.IsAny<int>()), Times.AtLeastOnce);
            mockRule.Verify(x => x.IsBorn(It.IsAny<int>()), Times.AtLeastOnce);
        }

        [Fact()]
        public void Evolve_OneTime_WithSurvingCells_Should_Be_As_Expected()
        {
            // Arrange
            var mockRule = new Mock<IRule>();
            var seed = new GameCell(new Point(1, 2));
            var lifeSeed = new HashSet<ICell> { seed };
            mockRule.Setup(x => x.IsBorn(It.IsAny<int>())).Returns(false);
            mockRule.Setup(x => x.DoesSurvive(It.IsAny<int>())).Returns(true);

            // Act
            var sut = new Universe(mockRule.Object, lifeSeed);
            var evolvedUniverse = sut.Evolve();

            // Asserts
            evolvedUniverse.Should().BeEquivalentTo(sut);
            evolvedUniverse.LivingCells.Should().HaveCount(1);
            evolvedUniverse.LivingCells.Single().Should().Be(seed);
            mockRule.Verify(x => x.DoesSurvive(It.IsAny<int>()), Times.AtLeastOnce);
            mockRule.Verify(x => x.IsBorn(It.IsAny<int>()), Times.AtLeastOnce);
        }

        [Fact()]
        public void Evolve_OneTime_WithSurvingCells_AndBornCells_Should_Be_As_Expected()
        {
            // Arrange
            var mockRule = new Mock<IRule>();
            var seed = new GameCell(new Point(1, 2));
            var lifeSeed = new HashSet<ICell> { seed };
            mockRule.Setup(x => x.IsBorn(It.IsAny<int>())).Returns(true);
            mockRule.Setup(x => x.DoesSurvive(It.IsAny<int>())).Returns(true);

            // Act
            var sut = new Universe(mockRule.Object, lifeSeed);
            var evolvedUniverse = sut.Evolve();

            // Asserts
            evolvedUniverse.Should().NotBeEquivalentTo(sut);
            evolvedUniverse.LivingCells.Should().HaveCount(9);
            mockRule.Verify(x => x.DoesSurvive(It.IsAny<int>()), Times.AtLeastOnce);
            mockRule.Verify(x => x.IsBorn(It.IsAny<int>()), Times.AtLeastOnce);
        }
    }
}