using System;
using Xunit;
using FizzBuzz;
using System.Threading;

namespace FizzBuzz_Tester
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(4, false)]
        [InlineData(53, true)]
        [InlineData(64, false)]
        [InlineData(1123, true)]

        public void PrimeCatcherTest(int number, bool correct)
        {
            bool actual = Program.IsPrime(number, false);
            Assert.Equal(actual, correct);

        }
        [Fact]
        public void BeepTest()
        {

            Program.Fizz("", 15, false);
            Thread.Sleep(1000);

            Program.Buzz("", 15, false);
            Thread.Sleep(1000);

            Program.IsPrime(2, false);
            Thread.Sleep(1000);

            Program.OddEven(4, true, false);
            Thread.Sleep(1000);
            Program.OddEven(9, true, false);

        }


        [Theory]
        [InlineData(1, "ODD")]
        [InlineData(0, "EVEN")]
        [InlineData(22, "EVEN")]
        [InlineData(1799, "ODD")]
        [InlineData(84, "EVEN")]
        [InlineData(8993, "ODD")]
        public void TestOddEven(int tester, string correct)
        {
            string result = Program.OddEven(tester, false, false);
            Assert.Equal(result, correct);

        }

        [Theory]
        [InlineData(0, "0")]
        [InlineData(2, "10")]
        [InlineData(64, "1000000")]
        [InlineData(5, "101")]
        [InlineData(1000, "1111101000")]
        public void TestBinConv(int tester, string correct)
        {
            string result = Program.BinConv(tester);
            Assert.Equal(correct, result);

        }


    }
}
