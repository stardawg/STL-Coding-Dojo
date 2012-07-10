using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzzKata
{
    public class FizzBuzz
    {
        public const string FIZZ = "Fizz";
        public const string BUZZ = "Buzz";

        public Dictionary<int, Func<int, string>> SomethingToStore;

        public FizzBuzz()
        {
            SomethingToStore = new Dictionary<int, Func<int, string>>();

            SomethingToStore.Add(3, FizzBuzz);
            SomethingToStore.Add(2, Fizz);
            SomethingToStore.Add(1, Buzz);
            SomethingToStore.Add(0, NumberToString);

        }

        public string Fizz(int something)
        {
            return "Fizz";
        }

        public string Buzz(int something)
        {
            return "Buzz";
        }

        public string NumberToString(int something)
        {
            return something.ToString();
        }

        public string FizzBuzz(int something)
        {
            return "FizzBuzz";
        }


    

        public string  PrintNumber(int number)
        {
            bool[] something = { (number % 3 == 0), (number % 5 == 0) };
            something.ToInt();
            
            var key = (new System.Collections.BitArray((number % 3==0), (number % 5==0))); 
            return SomethingToStore[key].Invoke(number);   








            //string returnString = string.Empty;
            //if (number % 3 == 0)
            //    returnString += FIZZ;
            //if (number % 5 == 0)
            //    returnString += BUZZ;
            
            //if(returnString==string.Empty)
            //    returnString= number.ToString();

            //return returnString;

            //return FizzBuzzState.GetInstance(number).PrintNumber(number);

            //return string.Format("{0}{1}", newMethod(3, number, FIZZ), newMethod(5, number, BUZZ));



        }

        public string newMethod(int divorsnumber, int number, string something)
        {
            return (number % divorsnumber)==0 ? something : string.Empty;
        }


        
    }
}
