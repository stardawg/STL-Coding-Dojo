using KataGameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameTest
{
    [TestClass()]
    public class GameTest
    {
        static readonly string kataBoard =
@"........
....*...
...**...
........";


        [TestMethod]
        public void ICanLoadAGameBoard()
        {
            var game = new GameOfLife();

            game.Load(kataBoard);
        }

        [TestMethod]
        public void LoadedBoardHasRightSize()
        {
            var game = new GameOfLife();

            game.Load(kataBoard);

            Assert.AreEqual(new Size(4, 8), game.Size);
        }

        [TestMethod]
        public void ICanGetTheLoadedBoard()
        {
            var game = new GameOfLife();

            game.Load(kataBoard);

            Assert.AreEqual(kataBoard, game.Board);
        }

        [TestMethod]
        public void ACellWithZeroNeighborsDies()
        {
            var game = new GameOfLife();

            game.Load(
@"...
.*.
..."
            );

            game.RunGeneration();

            Assert.AreEqual(
@"...
...
...",
                game.Board
            );
        }

        [TestMethod]
        public void ACellOnTheEdgeWithNoNeighborsDies()
        {
             var game = new GameOfLife();

            game.Load(
@"*.*
...
*.*"
            );

            game.RunGeneration();

            Assert.AreEqual(
@"...
...
...",
                game.Board
            );
        }

        [TestMethod]
        public void ACellWithExactlyOneNeighborDies()
        {
            var game = new GameOfLife();

            game.Load(
@".*.
.*.
..."
            );

            game.RunGeneration();

            Assert.AreEqual(
@"...
...
...",
                game.Board
            );
        }
    }
}
