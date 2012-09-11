using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace KataGameOfLife
{
    struct Size
    {
        public int Height;
        public int Width;

        public Size(int height, int width)
        {
            // TODO: Complete member initialization
            this.Height = height;
            this.Width = width;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", Height, Width);
        }
    }
}
