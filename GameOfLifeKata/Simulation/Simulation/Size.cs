using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulation
{
    public struct Size
    {
        public int Rows { get; private set; }
        public int Cols { get; private set; }

        public Size(int numRows, int numCols)
            : this()
        {
            Rows = numRows;
            Cols = numCols;
        }
    }


    //public class Size
    //{
    //    public int Rows { get; private set;}
    //    public int Cols { get; private set;}

    //    public Size(int numRows, int numCols)
    //    {
    //        Rows = numRows;
    //        Cols = numCols;
    //    }
    //}
}
