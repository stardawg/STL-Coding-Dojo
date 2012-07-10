using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzzKata
{
    class FizzState : FizzBuzzState
    {
        internal override string PrintNumber(int number)
        {
            return "Fizz";
        }
    }
}
