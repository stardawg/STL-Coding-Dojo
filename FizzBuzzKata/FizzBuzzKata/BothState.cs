using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzzKata
{
    class BothState : FizzBuzzState
    {
        internal override string PrintNumber(int number)
        {
            return "FizzBuzz";
        }
    }
}
