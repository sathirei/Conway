using Xunit;
using System;
using System.Collections.Generic;
using Moq;
using GameOfLife.Core.IO;
using GameOfLife.Core.Rules;
using System.IO;
using FluentAssertions;
using GameOfLife.Domain;

namespace GameOfLife.App.Tests
{
    public class GameOfLifeTests
    {
        [Fact()]
        public void Run_Should_Provide_Output_As_Expected_For_Sample_Input_1()
        {
            // Arrange
            var mockGameInputReader = new Mock<IGameInputReader>();
            var outputWriter = new ConsoleGameOutputWriter();
            var output = new StringWriter();
            Console.SetOut(output);
            var conwaysRule = new ConwaysRule();

            mockGameInputReader.Setup(x => x.Read())
                .Returns((3, new HashSet<Domain.ICell>
                {
                    new GameCell(new Point(2, 1)),
                    new GameCell(new Point(2, 2)),
                    new GameCell(new Point(2, 3))
                }));

            // Act
            var sut = new GameOfLife(mockGameInputReader.Object, conwaysRule, outputWriter);

            sut.Run();
            var capturedOutput = output.ToString().Trim('\r', '\n');

            // Asserts
            capturedOutput.Should().Be("[(1,2), (2,2), (3,2)]");
        }

        [Fact()]
        public void Run_Should_Provide_Output_As_Expected_For_Sample_Input_2()
        {
            // Arrange
            var mockGameInputReader = new Mock<IGameInputReader>();
            var outputWriter = new ConsoleGameOutputWriter();
            var output = new StringWriter();
            Console.SetOut(output);
            var conwaysRule = new ConwaysRule();

            mockGameInputReader.Setup(x => x.Read())
                .Returns((5, new HashSet<Domain.ICell>
                {
                    new GameCell(new Point(9, 8)),
                    new GameCell(new Point(10, 9)),
                    new GameCell(new Point(8, 10)),
                    new GameCell(new Point(9, 10)),
                    new GameCell(new Point(10, 10))
                }));

            // Act
            var sut = new GameOfLife(mockGameInputReader.Object, conwaysRule, outputWriter);

            sut.Run();
            var capturedOutput = output.ToString().Trim('\r', '\n');

            // Asserts
            capturedOutput.Should().Be("[(9,10), (10,11), (10,12), (11,10), (11,11)]");
        }

        [Fact()]
        public void Run_Should_Provide_Output_As_Expected_For_Sample_Input_3()
        {
            // Arrange
            var mockGameInputReader = new Mock<IGameInputReader>();
            var outputWriter = new ConsoleGameOutputWriter();
            var output = new StringWriter();
            Console.SetOut(output);
            var conwaysRule = new ConwaysRule();

            mockGameInputReader.Setup(x => x.Read())
                .Returns((10, new HashSet<Domain.ICell>
                {
                    new GameCell(new Point(1, 2)),
                    new GameCell(new Point(2, 1)),
                    new GameCell(new Point(2, 3)),
                    new GameCell(new Point(3, 2))
                }));

            // Act
            var sut = new GameOfLife(mockGameInputReader.Object, conwaysRule, outputWriter);

            sut.Run();
            var capturedOutput = output.ToString().Trim('\r', '\n');

            // Asserts
            capturedOutput.Should().Be("[(1,2), (2,1), (2,3), (3,2)]");
        }
    }
}