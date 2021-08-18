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
            bool actual = Number.IsPrime(number);
            Assert.Equal(actual, correct);

        }


        [Fact]
        public void BeepTest()
        {

            Number.ShowCount(16);
            Thread.Sleep(1000);

            Number.FizzBuzz("f", "b", 6);
            Thread.Sleep(1000);
            Number.FizzBuzz("f", "b", 10);
            Thread.Sleep(1000);
            Number.FizzBuzz("f", "b", 15);
            Thread.Sleep(1000);

            Number.IsPrime(3);
            Thread.Sleep(1000);

            Number.OddEven(0);
            Thread.Sleep(1000);
            Number.OddEven(1);



            /* older methods
            Program.Fizz("", 15, false);
            Thread.Sleep(1000);

            Program.Buzz("", 15, false);
            Thread.Sleep(1000);

            Program.IsPrime(2, false);
            Thread.Sleep(1000);

            Program.OddEven(4, true, false);
            Thread.Sleep(1000);
            Program.OddEven(9, true, false);*/

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
            string result = Number.OddEven(tester);
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
            string result = Number.BinConv(tester);
            Assert.Equal(correct, result);

        }
        [Fact]
        public void UI_OPT_TEST()
        {
            string OPT = $"\n\nOPTIONS | FIZZ = f | BUZZ = b | COLORS = {UI.COLOR_ON} | BEEPS ON = {UI.BEEP_ON} | LOOP = {UI.LOOP_UI} | EVEN_ODD = {UI.ODD_EVENS} | DECIMAL = {UI.SHOW_DECI} //";
            Assert.Equal(OPT, UI.SHOW_OPTIONS("f", "b"));
        }

        [Theory]     
        [InlineData("************************************************* SuperFizzBuzz ver 1.xxx *************************************************\n", 125)]
        [InlineData("**************************************** SuperFizzBuzz ver 1.xxx ****************************************\n", 106)]
        public void UI_TEST(string correct, int window_w) 
        {
            UI.WINDOW_WIDTH = window_w;
            Assert.True(correct.Length == UI.SHOW_HEADER().Length);
        }


    }
}
