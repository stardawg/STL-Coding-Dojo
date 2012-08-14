using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulation
{
    public class Board
    {
        private Size _size;
        public Size Size
        {
            get{
                return _size;
            }
        }

        private List<object> _rows;
        public List<object> Rows
        {
            get
            {
                return _rows;
            }
        }

        public Board(Size boardSize)
        {
            _size = new Size(boardSize.Rows, boardSize.Cols);
            _rows = new List<object>(new object[boardSize.Rows]);
            
        }

    }
}
