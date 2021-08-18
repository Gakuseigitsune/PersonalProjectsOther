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
        //1.61L moved bool flags into classes as statics, UI class added, moved prime method into Number class, combined Fizz and Buzz methods into a single method
        //1.70L all methods migrated into classes, DEFAULT class added, all tests updated to work with new methods
        //1.75L tweaks to UI padding logic, corrected bugs in FizzBuzz/ShowCOunt
        //1.77L tweaks to FizzBuzz 3 is treated as Fizz and not as a prime; added visual toggle for Prime numbers when colors are off and not in OddEven mode 
        //1.9 planned > add ability for user to change flags
        public static string CurrVersion = "1.77L";

    }


    public class DEFAULT
    {
        public static int COUNT = 100;
        public static string[] FIZZ_BUZZ = { "Fizz", "Buzz" };


    }

    public class UI
    {
        //flags
        public static bool COLOR_ON = false;
        public static bool BEEP_ON = true;
        public static bool SHOW_DECI = true;
        public static bool ODD_EVENS = true;
        public static bool LOOP_UI = true;


        public static string TITLE = "SuperFizzBuzz";
        public static int WINDOW_WIDTH = 125;
        

        public static string SHOW_HEADER()
        {
            char PADDING_CH = '*';
            string PADDING = "";
            string HEADER_FORMAT = "{0} {1} ver {2} {0}\n";
            


            int padSize = (UI.WINDOW_WIDTH - 8 - UI.TITLE.Length - Version.CurrVersion.Length) / 2;
            for (int i = 0; i < padSize; i++) PADDING += PADDING_CH.ToString();

            return string.Format(HEADER_FORMAT, PADDING, UI.TITLE, Version.CurrVersion); 

        }

        public static string SHOW_OPTIONS(string fizz, string buzz)
        {
            string OPT_FORMAT = "\n\nOPTIONS | FIZZ = {0} | BUZZ = {1} | COLORS = {2} | BEEPS ON = {3} | LOOP = {4} | EVEN_ODD = {5} | DECIMAL = {6} //";

            return String.Format(OPT_FORMAT, fizz, buzz, UI.COLOR_ON, UI.BEEP_ON, UI.LOOP_UI, UI.ODD_EVENS, UI.SHOW_DECI);

        }

        public static void SHOW_UI()
        {
            string userInp, userInp2;
            string fizz, buzz;


            Console.Write("\tPlease enter two words separated by a space to use for fizz and buzz\n\t(or leave blank for defaults):  ");  
            userInp = Console.ReadLine();
            Console.Write("\tPlease enter a number to count up to (or leave blank for default):  ");
            userInp2 = Console.ReadLine();

            if (!Int32.TryParse(userInp2, out int usrCount)) usrCount = DEFAULT.COUNT;


            if (String.IsNullOrWhiteSpace(userInp) || userInp.Length < 2)                                     //..if empty set Fizz and Buzz to defaults
            {
                fizz = DEFAULT.FIZZ_BUZZ[0];
                buzz = DEFAULT.FIZZ_BUZZ[1];
            }
            else                                                                                              //set Fizz and Buzz as substrings
            {                                                                                                 //split user input based on ' ' as delimiter
                string[] fizzBuzz = userInp.Split(' ');
                fizz = fizzBuzz[0];
                buzz = fizzBuzz[1];
            }

            Console.WriteLine("{0}\n", UI.SHOW_OPTIONS(fizz, buzz) );
          

            for (int count = 0; count <= usrCount; count++)                                                  
            {
                if (UI.ODD_EVENS)
                {
                    Console.Write(Number.OddEven(count));
                    if (count % 10 == 0 && count > 0) Console.Write($"  ({count})");
                    Console.Write("\n");

                    Thread.Sleep(550);
                    Console.ResetColor();
                    continue;                                                                               //Odd even mode overrides other flags
                }

                Number.FizzBuzz(fizz, buzz, count);
                Thread.Sleep(550);                                                                           
            }
            Console.Write("\n");

        }

    }



    public class Number
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


        public static bool IsPrime(int count)
        {

            if (count <= 1) return false;
            if ((count % 2 == 0 && count != 2) || count == 1) return false;

            if (count != 2)
            {
                for (int j = 3; j < count; j++) if (count % j == 0) return false;
            }


            if (UI.COLOR_ON) Console.ForegroundColor = ConsoleColor.Cyan;
            else if (!UI.COLOR_ON && !UI.ODD_EVENS) Console.Write("(P) ");


            if (UI.BEEP_ON)
            {
                Console.Beep(1000, 10);
                Console.Beep(1200, 25);
            }

            return true;
        }


        public static string OddEven(int count)
        {
            string numtype;

            if (Number.IsPrime(count))
            {
                numtype = "PRIME!";
                return numtype;
            }

            if (count % 2 == 0)
            {
                numtype = "EVEN";
                if (UI.BEEP_ON) Console.Beep(1650, 150);
                if (UI.COLOR_ON) Console.ForegroundColor = ConsoleColor.Red;
                return numtype;
            }
            else
            {
                numtype = "ODD";
                if (UI.BEEP_ON) Console.Beep(750, 150);
                if (UI.COLOR_ON) Console.ForegroundColor = ConsoleColor.DarkGreen;
                return numtype;
            }

        }

        public static void FizzBuzz(string fizz, string buzz, int count)
        {

            if (count % 3 == 0 && count % 5 == 0 && count != 0)                              //FizzBuzz
            {
                if (UI.COLOR_ON) Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{fizz}");
                
                if (UI.COLOR_ON) Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"{buzz}\n");

                if (UI.BEEP_ON)
                {
                    Console.Beep(3000, 300);
                    Console.Beep(900, 300);
                }

                Console.ResetColor();
                return;

            }
            else if (count % 3 == 0 && count != 0)                                           //Fizz
            {
                if (UI.COLOR_ON) Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{fizz}\n");
                if (UI.BEEP_ON) Console.Beep(3000, 300);
                Console.ResetColor();
                return;

            }
            else if (count % 5 == 0 && count != 0)                                           //Buzz
            {
                if (UI.COLOR_ON) Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"{buzz}\n");
                if (UI.BEEP_ON) Console.Beep(900, 300);
                Console.ResetColor();
                return;
            }

            if (!Number.IsPrime(count))                                                     //Neither
            {
                if (UI.COLOR_ON) Console.ForegroundColor = ConsoleColor.White;
                if (UI.BEEP_ON) Console.Beep(500, 50);
            }
                                                                                       
            Console.Write($"{BinConv(count)}");

            if (UI.SHOW_DECI)
            {
                if (UI.COLOR_ON) Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($" ({count})");
            }

            Console.Write("\n");
            Console.ResetColor();

            return;
        }

        public static void ShowCount(int count)  //not actually used as fuctionality is built into FizzBuzz
        {
            if (!Number.IsPrime(count))
            {
                if (UI.BEEP_ON) Console.Beep(500, 50);
                if (UI.COLOR_ON) Console.ForegroundColor = ConsoleColor.Gray;

            }


            Console.Write($"{BinConv(count)}");

            if (UI.SHOW_DECI)
            {
                if (UI.COLOR_ON) Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($" ({count})");

            }

            Console.Write("\n");
            Console.ResetColor();

        }


    }




    public class Program
    {
        //all methods updated and moved into classes as of ver 1.7L

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

        public static void FizzBuzz(string b, string f, int count)
        {
            if (!Number.IsPrime(count))
            {
                if (count % 3 == 0 && count % 5 == 0)
                {
                    if (UI.COLOR_ON) Console.ForegroundColor = ConsoleColor.Green;
                    if (UI.BEEP_ON) Console.Beep(3000, 300);
                    Console.Write($"{f}");
                    if (UI.COLOR_ON) Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    if (UI.BEEP_ON) Console.Beep(900, 300);
                    Console.Write($"{b}");


                }
                else if (count % 3 == 0)
                {
                    if (UI.COLOR_ON) Console.ForegroundColor = ConsoleColor.Green;
                    if (UI.BEEP_ON) Console.Beep(3000, 300);
                    Console.Write($"{f}");

                }
                else
                {
                    if (UI.COLOR_ON) Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    if (UI.BEEP_ON) Console.Beep(900, 300);
                    Console.Write($"{b}");

                }
            }

            

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
     
        public static bool SHOW_UI()
        {

           
            string userInp, userInp2;
            string fizz, buzz;


            bool showDecimal = true;                                                                       //show decimal alongside binary
            bool loopUI = true;                                                                            //toggle for looping app
            bool OddEvens = false;                                                                          //toggle for EVEN ODD (overrides output)
            bool colorOn = false;                                                                          //Color coding on output



            
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
            Console.SetWindowSize(UI.WINDOW_WIDTH, 50);

            Console.WriteLine(UI.SHOW_HEADER());

            while (UI.LOOP_UI) 
            {

                UI.SHOW_UI();
            
            }
            Console.ReadLine();

        }
    }
}
