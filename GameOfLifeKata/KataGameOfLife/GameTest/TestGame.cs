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

        private GameOfLife target;

        [TestInitialize()]
        public void setupTest()
        {
            target = new GameOfLife();
        }

        #region Game Load Tests
        [TestMethod]
        public void ICanLoadAGameBoard()
        {

            target.Load(kataBoardWith4RowsOf8Columns);
        }

        [TestMethod]
        public void LoadedBoardHasRightSize()
        {
            target.Load(kataBoardWith4RowsOf8Columns);

            Assert.AreEqual(new Size(4, 8), target.Size);
        }

        [TestMethod]
        public void ICanGetTheLoadedBoard()
        {
            var target = new GameOfLife();

            target.Load(kataBoardWith4RowsOf8Columns);

            Assert.AreEqual(kataBoardWith4RowsOf8Columns, target.Board);
        }

        [TestMethod,
        ExpectedException(typeof(InitializationException))
        ]
        public void IfITryToLoadAJaggedBoardGameThrowsInitializationException()
        {
            

            target.Load(kataBoardWithJaggedRows);
        }

        #endregion

        #region Underpopulation Cases

        [TestMethod]
        public void ACellWithZeroNeighborsDies()
        {
            

            target.Load(
@"...
.*.
..."
            );

            target.RunGeneration();

            Assert.AreEqual(BOARD_3_X_3_NO_LIVE_CELLS, target.Board);
        }

        [TestMethod]
        public void ACellOnTheEdgeWithNoNeighborsDies()
        {
            

            target.Load(
@"*.*
...
*.*"
            );

            target.RunGeneration();

            Assert.AreEqual(BOARD_3_X_3_NO_LIVE_CELLS, target.Board);
        }

        [TestMethod]
        public void ACellWith2NeighborsLivesAnd2NeighborsDieWhen3InAHorizontalRow()
        {
            
            target.Load(
@"...
***
..."
);
            target.RunGeneration();

            string cells = 
@"...
.*.
...";

            Assert.AreEqual(cells, target.Board);

        }

        [TestMethod]
        public void ACellWith2NeighborsLivesAnd2NeighborsDieWhen3InAVerticalRow()
        {
                      setupTest();
            target.Load(
@"..*.
..*.
..*.
...."
);

            target.RunGeneration();

            string cells = 
@"....
..*.
....
....";
            Assert.AreEqual(cells, target.Board);
  
        }


        [TestMethod]
        public void ACellWith3NeighborsLivesAndIsDeadComesToLife()
        {
            setupTest();
            target.Load(
@".**.
..*.
....
...."
);

            target.RunGeneration();

            string cells =
@"..*.
.*..
....
....";
            Assert.AreEqual(cells, target.Board);

        }


        [TestMethod]
        public void ACellWithExactlyOneNeighborDies()
        {
            

            target.Load(
@".*.
.*.
..."
            );

            target.RunGeneration();

            Assert.AreEqual(BOARD_3_X_3_NO_LIVE_CELLS, target.Board);
        }

        #endregion

        #region Overpopulation Cases

        [TestMethod]
        public void ACellWithFourNeighborsDies()
        {
            

            target.Load(
@".......
..***..
..***..
..***..
......."
            );

            target.RunGeneration();

            Assert.AreEqual(
@".......
..***..
..*.*..
..***..
......."
                , target.Board);
        }



        #endregion
    }
}
