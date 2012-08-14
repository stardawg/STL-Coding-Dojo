using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulation
{
    public class Game
    {
        private int _rows;
        private int _columns;
        private object[] _cells;

        //public Game(int rows, int columns)
        //{
        //    // TODO: Complete member initialization
        //    this._rows = rows;
        //    this._columns = columns;
        //    _cells = new object[rows * columns];
        //    Board = new Board(rows, columns);
        //}

        public Game(Size gameSize)
        {
            // TODO: Complete member initialization
            this._rows = gameSize.Rows;
            this._columns = gameSize.Cols;
            _cells = new object[gameSize.Rows * gameSize.Cols];
            Board = new Board(gameSize);
        }

        public IList<object> Cells
        {
            get { return _cells.ToList().AsReadOnly(); }
        }

        public Board Board { get; set; }
    }
}
