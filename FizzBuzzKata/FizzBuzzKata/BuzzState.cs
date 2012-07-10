using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzzKata
{
    class BuzzState : FizzBuzzState
    {
        internal override string PrintNumber(int number)
        {
            return "Buzz";
        }
    }
}
