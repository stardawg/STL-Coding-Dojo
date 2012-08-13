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

        public Game(int rows, int columns)
        {
            // TODO: Complete member initialization
            this._rows = rows;
            this._columns = columns;
            _cells = new object[rows * columns];

        }

        public IList<object> Cells
        {
            get { return _cells.ToList().AsReadOnly(); }
        }
    }
}
