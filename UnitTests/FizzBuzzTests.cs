using System;
using System.Collections.Generic;
using System.Linq;
using ClearMeasureHomework;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void DivisibleByThreeAndFiveReturnBothWordPairs()
        {            
            var input = new FizzBuzzInput {Length = 100};

            var expectedIndexes = new List<int>();
            for (var i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    expectedIndexes.Add(i);
            }

            var expectedOutput = $"{string.Join(" ", input.FizzWords)} {string.Join(" ", input.BuzzWords)}";
            var fb = new FizzBuzz();
            
            var results = fb.Run(input).ToList();

            foreach (var index in expectedIndexes)
            {
                Assert.AreEqual(results[index - 1], expectedOutput);
            }            
        }

        [Ignore("Takes too  long to run.")] 
        [Test]
        public void MaxLengthDoesNotRunOutOfMemory()
        {
            var input = new FizzBuzzInput { Length = int.MaxValue };
            var fb = new FizzBuzz();
            var maxResults = int.MaxValue;

            var counter = 0;
            foreach (var item in fb.Run(input))
            {
                counter++;
            }

            Assert.AreEqual(counter, int.MaxValue);           
        }

        [Test]
        public void NullInputThrowsArgumentNullException()
        {
            try
            {
               var fb = new FizzBuzz();
                foreach (var item in fb.Run(null))
                {

                }
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.Message.Length > 0);
                return;
            }

            // Fails if we get here
            Assert.IsTrue(false);
        }

        [Test]
        public void LengthLessThanZeroThrowsArgumentOutOfRangeException()
        {            
            try
            {
                var input = new FizzBuzzInput { Length = -1 };
                var fb = new FizzBuzz();
                foreach (var item in fb.Run(input))
                {
                    
                }                
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(ex.Message.Length > 0);
                return;
            }

            // Fails if we get here
            Assert.IsTrue(false);
        }
    }

    public class FizzBuzzInput : IInput
    {
        public List<string> FizzWords { get; set; }
        public List<string> BuzzWords { get; set; }
        public int Length { get; set; }

        public FizzBuzzInput()
        {
            // Setup defaults
            FizzWords = new List<string> {"Fizz"};
            BuzzWords = new List<string>{"Buzz"};
            Length = 100;
        }
    }
}
