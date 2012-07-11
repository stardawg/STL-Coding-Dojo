using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzzKata
{
    class BuzzState : FizzBuzzStateBase
    {
        internal BuzzState(FizzBuzz context) : base(context) { }

        internal override string PrintNumber()
        {
            return "Buzz";
        }
    }
}
