﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzzKata
{
    class FizzBuzzState : FizzBuzzStateBase
    {
        internal FizzBuzzState(FizzBuzz context) : base(context) { }

        internal override string PrintNumber()
        {
            return "FizzBuzz";
        }
    }
}
