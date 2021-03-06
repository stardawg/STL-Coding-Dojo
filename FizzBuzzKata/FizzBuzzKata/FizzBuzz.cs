﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FizzBuzzKata
{
    public class FizzBuzz
    {
        public const string FIZZ = "Fizz";
        public const string BUZZ = "Buzz";

        private FizzBuzzStateBase _state;
        private Dictionary<int, FizzBuzzStateBase> _printStateMachine;


        public int Number { get; private set; }

        public FizzBuzz()
        {
            _state = new FizzBuzzStateBase(this);
            _printStateMachine = new Dictionary<int, FizzBuzzStateBase>
            {
                {0, new NumberState(this)},
                {1, new FizzState(this)},
                {10, new BuzzState(this)},
                {11, new FizzBuzzState(this)}
            };

        }

        public string PrintNumber(int number)
        {
            Number = number;
            int lowBit = Convert.ToInt32(number % 3 == 0);
            int highBit = Convert.ToInt32(number % 5 == 0);

            _state = _printStateMachine[lowBit + (highBit * 10)];
            return _state.PrintNumber();
        }
    }
}
