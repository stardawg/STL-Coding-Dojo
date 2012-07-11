using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzzKata
{
  
    public class FizzBuzzStateBase
    {
        protected FizzBuzz _context;

        internal FizzBuzzStateBase(FizzBuzz context)
        {
            _context = context;
        }

        //protected void InitStateMachine()
        //{
        //}

        internal virtual string PrintNumber()
        {
            throw new InvalidOperationException();
        }

        //public FizzBuzzStateBase GetInstance(int number)
        //{
        //    InitStateMachine();
        //    FizzBuzzStateBase result;

        //    try
        //    {
        //        result = _printStateMachine[number];
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        return _printStateMachine[0];
        //    }
                
        //    return result;
        //}

    }
}
