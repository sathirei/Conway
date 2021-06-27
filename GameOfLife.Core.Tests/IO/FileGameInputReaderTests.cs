using Xunit;
using System;
using FluentAssertions;
using GameOfLife.Core.Exception;

namespace GameOfLife.Core.IO.Tests
{
    public class FileGameInputReaderTests
    {
        [Fact()]
        public void Read_Should_Succeed()
        {
            // Arrange
            var inputPath = "./IO/TestInput/validInput.txt";

            // Act
            var sut = new FileGameInputReader(inputPath);
            var (noOfEvolution, lifeSeed) = sut.Read();

            // Asserts
            noOfEvolution.Should().Be(5);
            lifeSeed.Count.Should().Be(5);
        }

        [Fact()]
        public void Read_Should_Fail()
        {
            // Arrange
            var inputPath = "./IO/TestInput/invalidInput.txt";

            // Act
            var sut = new FileGameInputReader(inputPath);
            Action act = () => sut.Read();

            // Asserts
            act.Should().Throw<InvalidInputException>();
        }
    }
}