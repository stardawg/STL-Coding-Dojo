using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzzKata
{
  
    public class FizzBuzzState
    {
        internal virtual string PrintNumber(int number)
        {
            throw new InvalidOperationException();
        }

        public static FizzBuzzState GetInstance(int number)
        {
            if(number % 15 == 0)
                return new BothState();
            if(number % 3 == 0)
                return new FizzState();
            if(number % 5 == 0)
                return new BuzzState();
                
            return new NumberFizzBuzzState();
        }

    }
}
