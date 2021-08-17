using System;
using System.Threading;

namespace FizzBuzz
{

   
    



    public class Version
    {


        //1.50 recoded most of original methods, added colors and beeps; moved functionality out of main; implemented tests
        //1.50L added even odd functionality for practice lab, added as basic boolean toggle option 
        //1.57L added color toggle, added Header UI method
        //1.58L changed prime color to cyan, slightly tweaked Prime check logic (explicity checks for 0 and 1); changed fizzbuzz to use string.split instead of substring

        public static string CurrVersion = "1.58L";

    }
    public class Program
    {
        public static string BinConv(int count)
        {
            bool isOdd;
            double result, tst;

            if (count == 1) return "1";

            tst = 0;

            do                                                    //loop until a correct base is found
            {
                tst++;
                result = Math.Pow(2, tst);
            }
            while (result <= count);



            if (count % 2 == 0) isOdd = false;                    //check for even #s
            else isOdd = true;


            char[] output = new char[(int)tst];



            for (int j = 0; j <= output.Length - 1; j++)
            {

                double exp = output.Length - 1 - j;

                if (count - (int)Math.Pow(2, exp) < 0) output[j] = '0';
                else
                {
                    output[j] = '1';
                    count -= (int)Math.Pow(2, exp);
                }



            }

            if (isOdd) output[(int)tst - 1] = '1';

            string binaryNum = new string(output);

            return binaryNum;

        }

        public static void Fizz(string f, int count, bool colorOn)
        {
            if (!IsPrime(count, colorOn))
            {
                if (colorOn) Console.ForegroundColor = ConsoleColor.Green;
                Console.Beep(3000, 300);
            }

            Console.Write($"{f}");

            Console.ResetColor();
        }

        public static void Buzz(string b, int count, bool colorOn)
        {
            if (!IsPrime(count, colorOn))
            {

                if (colorOn) Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Beep(900, 300);
            }

            Console.Write($"{b}");

            Console.ResetColor();
        }

        public static void ShowCount(bool showDeci, int count, bool colorOn)
        {
            IsPrime(count, colorOn);

            Console.Write($"{BinConv(count)}");
            if (showDeci) Console.Write($" ({count})");
            Console.Write("\n");
            Console.ResetColor();
        }

        public static bool IsPrime(int count, bool colorOn)
        {

            if (count <= 1) return false;
            if ((count % 2 == 0 && count != 2) || count == 1) return false;

            if (count != 2)
            {
                for (int j = 3; j < count; j++) if (count % j == 0) return false;
            }




            if (colorOn) Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Beep(1000, 90);
            Console.Beep(1200, 50);


            return true;
        }

        public static string OddEven(int count, bool beepOn, bool colorOn)
        {
            string numtype;



            if (IsPrime(count, colorOn))
            {
                numtype = "PRIME!";
                return numtype;
            }


            if (count % 2 == 0)
            {
                numtype = "EVEN";
                if (beepOn) Console.Beep(1650, 150);
                if (colorOn) Console.ForegroundColor = ConsoleColor.DarkYellow;
                return numtype;
            }
            else
            {
                numtype = "ODD";
                if (beepOn) Console.Beep(750, 150);
                if (colorOn) Console.ForegroundColor = ConsoleColor.DarkGreen;
                return numtype;
            }



        }

        public static void UI_HEADER()
        {
            int windowWidth = 100;
            string title = "SuperFizzBuzz";
            string padding = "*";

            Console.SetWindowSize(windowWidth, 50);
            //Console.BackgroundColor = ConsoleColor.DarkGray;

            int padSize = ((windowWidth - 10) - 8 - title.Length - Version.CurrVersion.Length) / 2;

            for (int i = 0; i < padSize; i++) padding +="*";


            Console.WriteLine(" {0} {1} ver {2} {0}\n", padding, title, Version.CurrVersion);

        }

        public static bool UI()
        {

           
            string userInp, userInp2;
            string fizz, buzz;


            bool showDecimal = true;                                                                       //show decimal alongside binary
            bool loopUI = true;                                                                            //toggle for looping app
            bool OddEvens = false;                                                                          //toggle for EVEN ODD (overrides output)
            bool colorOn = true;                                                                          //Color coding on output



            
            Console.Write("\tPlease enter two words separated by a space to use for fizz and buzz\n\t(or leave blank for defaults):  ");                       //Prompt for input for 'fizz' and 'Buzz'
            userInp = Console.ReadLine();
            Console.Write("\tPlease enter a number to count up to (or leave blank for default):  ");
            
            userInp2 = Console.ReadLine();

            if (!Int32.TryParse(userInp2, out int usrCount)) usrCount = 100;


            if (String.IsNullOrWhiteSpace(userInp) || userInp.Length < 2)                                     //..if empty set Fizz and Buzz to defaults
            {
                fizz = "Fizz";
                buzz = "Buzz";
            }
            /* else                                                                                              //..otherwise set Fizz and Buzz as substrings
             {                                                                                                 // split based on lenght of user input
                 charCt = userInp.Length;
                 middle = charCt / 2;

                 fizz = userInp.Substring(0,middle);
                 buzz = userInp.Substring(middle);
             }*/
           else                                                                                              //set Fizz and Buzz as substrings
           {                                                                                                 //split user input based on ' ' as delimiter

                string[] fizzBuzz = userInp.Split(' ');
                fizz = fizzBuzz[0];
                buzz = fizzBuzz[1];

           }

            /* for (int count = 0; count < usrCount+1; count++)                                                  //count to 100; print Fizz for multiples of 3, Buzz for multples of 5
               {

                   if (count % 3 == 0 && count % 5 == 0 && count != 0) Console.Write($"{Fizz}{Buzz}\n");
                   else if (count % 3 == 0 && count != 0) Console.Write($"{Fizz}\n");
                   else if (count % 5 == 0 && count != 0) Console.Write($"{Buzz}\n");
                   else if (showDecimal) Console.Write($"{count}\n");
                   else Console.Write($"{BinConv(count)}\n");

               //  Console.Write("{0,25}\n",'('+BinConv(count)+')');                                          

                   Thread.Sleep(750);                                                                            // x msec delay between each count


               }*/

            Console.WriteLine("\n\n\tOPTIONS | FIZZ = {0} | BUZZ = {1} | COLORS = {2} | LOOP = {3} | EVEN-ODD = {4} //", fizz, buzz, colorOn, loopUI, OddEvens);

            for (int count = 0; count <= usrCount; count++)                                                  //count to 100; print Fizz for multiples of 3, Buzz for multples of 5
            {
                if (OddEvens)
                {
                    Console.Write( OddEven(count, true, colorOn) );
                    if (count % 10 == 0 && count > 0) Console.Write($"  ({count})");
                    Console.Write("\n");

                    Thread.Sleep(550);
                    Console.ResetColor();
                    continue;
                }

                if (count % 3 == 0 && count % 5 == 0 && count != 0)
                {
                    Fizz(fizz, count, colorOn);
                    Buzz(buzz, count, colorOn);
                    Console.Write("\n");
                }
                else if (count % 3 == 0 && count != 0)
                {
                    Fizz(fizz, count, colorOn);
                    Console.Write("\n");
                }
                else if (count % 5 == 0 && count != 0)
                {
                    Buzz(buzz, count, colorOn);
                    Console.Write("\n");
                }
                else ShowCount(showDecimal, count, colorOn);

                //  Console.Write("{0,25}\n",'('+BinConv(count)+')');                                          

                Thread.Sleep(550);                                                                            // x msec delay between each count

            }



            return loopUI;

        }




        static void Main(string[] args)
        {
            UI_HEADER();

            while (UI()) { }
            Console.ReadLine();

        }
    }
}
