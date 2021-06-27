using Xunit;
using System;
using System.Collections.Generic;
using GameOfLife.Core.Rules;
using Moq;
using GameOfLife.Domain;
using System.IO;
using FluentAssertions;

namespace GameOfLife.Core.IO.Tests
{
    public class ConsoleGameOutputWriterTests
    {
        [Fact()]
        public void Write_Should_Generate_Output_As_Expected()
        {
            // Arrange
            var mockRule = new Mock<IRule>();
            var lifeSeed = new HashSet<ICell>
            {
                new GameCell(new Point(1,3)),
                new GameCell(new Point(2,3)),
                new GameCell(new Point(4,3))
            };
            var universe = new Universe(mockRule.Object, lifeSeed);

            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            var sut = new ConsoleGameOutputWriter();
            sut.Write(universe);
            var capturedOutput = output.ToString().Trim('\r', '\n');

            // Asserts
            capturedOutput.Should().Be("[(1,3), (2,3), (4,3)]");
        }
    }
}