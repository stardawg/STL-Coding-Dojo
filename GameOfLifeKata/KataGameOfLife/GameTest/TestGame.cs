using KataGameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GameTest
{
    [TestClass()]
    public class TestGameWith4By8Size
    {
        private const string BOARD_3_X_3_NO_LIVE_CELLS = 
@"...
...
...";
        static readonly string kataBoardWith4RowsOf8Columns =
@"........
....*...
...**...
........";

        static readonly string kataBoardWithJaggedRows =
@"........
....*...
...**............................
........";


        #region Game Load Tests
        [TestMethod]
        public void ICanLoadAGameBoard()
        {
            var game = new GameOfLife();

            game.Load(kataBoardWith4RowsOf8Columns);
        }

        [TestMethod]
        public void LoadedBoardHasRightSize()
        {
            var game = new GameOfLife();

            game.Load(kataBoardWith4RowsOf8Columns);

            Assert.AreEqual(new Size(4, 8), game.Size);
        }

        [TestMethod]
        public void ICanGetTheLoadedBoard()
        {
            var game = new GameOfLife();

            game.Load(kataBoardWith4RowsOf8Columns);

            Assert.AreEqual(kataBoardWith4RowsOf8Columns, game.Board);
        }

        [TestMethod,
        ExpectedException(typeof(InitializationException))
        ]
        public void IfITryToLoadAJaggedBoardGameThrowsInitializationException()
        {
            var game = new GameOfLife();

            game.Load(kataBoardWithJaggedRows);
        }

        #endregion

        #region Underpopulation Cases

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

            Assert.AreEqual(BOARD_3_X_3_NO_LIVE_CELLS, game.Board);
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

            Assert.AreEqual(BOARD_3_X_3_NO_LIVE_CELLS, game.Board);
        }

        [TestMethod]
        public void ACellWith2NeighborsAliveLives()
        {
            var game = new GameOfLife();
            game.Load(
@"...
***
..."
);
            game.RunGeneration();

            string cells = 
@"...
.*.
...";

            Assert.AreEqual(cells, game.Board);
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

            Assert.AreEqual(BOARD_3_X_3_NO_LIVE_CELLS, game.Board);
        }

        #endregion

        #region Overpopulation Cases

        [TestMethod]
        public void ACellWithFourNeighborsDies()
        {
            var game = new GameOfLife();

            game.Load(
@".......
..***..
..***..
..***..
......."
            );

            game.RunGeneration();

            Assert.AreEqual(
@".......
..***..
..*.*..
..***..
......."
                , game.Board);
        }



        #endregion
    }
}
