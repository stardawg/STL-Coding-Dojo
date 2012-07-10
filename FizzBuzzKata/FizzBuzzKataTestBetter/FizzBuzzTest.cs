using FizzBuzzKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FizzBuzzKataTestBetter
{
    
    
    /// <summary>
    ///This is a test class for FizzBuzzTest and is intended
    ///to contain all FizzBuzzTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FizzBuzzTest
    {
        private FizzBuzz target;

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            target = new FizzBuzz();
        }
        

        /// <summary>
        ///A test for kevinisslacking
        ///</summary>
        [TestMethod()]
        public void NumberPrintsTest()
        {
            string actual = target.PrintNumber(1);

            Assert.AreEqual(1.ToString(), actual);
        }

        [TestMethod()]
        public void NumberDivisibleBy3ReturnsFizzTest()
        {
            string actual = target.PrintNumber(3);
            Assert.AreEqual(FizzBuzz.FIZZ, actual);
            actual = target.PrintNumber(6);
            Assert.AreEqual(FizzBuzz.FIZZ, actual);
        }

        [TestMethod()]
        public void NumberDivisibleBy5ReturnsBuzzTest()
        {
            string actual = target.PrintNumber(5);
            Assert.AreEqual(FizzBuzz.BUZZ, actual);
            actual = target.PrintNumber(10);
            Assert.AreEqual(FizzBuzz.BUZZ, actual);
        }

        [TestMethod()]
        public void NumberDivisbleBy3And5ReturnsFizzBuzz()
        {
            string actual = target.PrintNumber(15);
            Assert.AreEqual(FizzBuzz.FIZZ + FizzBuzz.BUZZ, actual);
            actual = target.PrintNumber(30);
            Assert.AreEqual(FizzBuzz.FIZZ + FizzBuzz.BUZZ, actual);
        }
    }
}
