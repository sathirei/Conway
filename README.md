# Game of Life

Conway's Game of Life, also known as the Game of Life is actually a zero-player game, 
meaning that its evolution is determined by its initial state, needing no input from human players.
One interacts with the Game of Life by creating an initial population and observing how it evolves.

Rules : 
The universe of the Game of Life is an infinite two-dimensional orthogonal grid of square cells, each of which is in one of two possible states, live or dead.

Every cell interacts with its eight neighbours, which are the cells that are directly horizontally, vertically, or diagonally adjacent. At each step in time, the following transitions occur:
Any live cell with fewer than two live neighbours dies (referred to as underpopulation).
Any live cell with more than three live neighbours dies (referred to as overpopulation).
Any live cell with two or three live neighbours lives, unchanged, to the next generation.
Any dead cell with exactly three live neighbours will come to life.

The initial pattern constitutes the 'seed' of the system. The first generation is created by applying the above rules simultaneously to every cell in the seed — births and deaths happen simultaneously.
In other words, each generation is a pure function of the one before.
The rules continue to be applied repeatedly to create further generations.

# Solution
The game is developed based on .NET Core framework. It is designed using C#. 

The projects are divided into Core, Domain and Application.

## Framework details
.NET Core 3.1

## Build
To build the project one can build the "GameOfLife.App" project and run it from Visual Studio.

It can also be done from console by running the following command from the GameOfLife solution folder

First restore the dependencies which is needed for building the solution

`dotnet restore`

and build it using the following command

`dotnet build`

## Test
Once the solution is built you can run the following command to run the tests

`dotnet test`

## Run
To run the project use the following command from command line or set "GameOfLife.App" as the startup project and run it from Visual Studio

`dotnet run`

# Improvement points
Currently the universe is not bounded e.g. (25,25) however this can be implemented easily.
