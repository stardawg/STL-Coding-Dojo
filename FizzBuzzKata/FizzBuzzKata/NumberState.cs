using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzzKata
{
    class NumberState : FizzBuzzStateBase
    {
        internal NumberState(FizzBuzz context) : base(context) { }

        internal override string PrintNumber()
        {
            return _context.Number.ToString();
        }
    }
}
