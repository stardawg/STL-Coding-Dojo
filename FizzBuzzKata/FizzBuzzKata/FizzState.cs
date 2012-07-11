using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzzKata
{
    class FizzState : FizzBuzzStateBase
    {
        internal FizzState(FizzBuzz context) : base(context) { }

        internal override string PrintNumber()
        {
            return FizzBuzz.FIZZ;
        }
    }
}
