using System;
using System.Threading;

namespace BinConverter
{
    class Program
    {

        static bool GetBase(string input, out int tstBase, out double usrNum, out bool isOdd)
        {
            isOdd = true;

            double result, num;
            if (!Double.TryParse(input, out num))          //invalid input
            {
                tstBase = -1;
                usrNum = 0;
                isOdd = false;

                return false;

            }
            else if (num == 1)
            {
                tstBase = 1;
                usrNum = num;
                isOdd = true;
                return true;
            }

            double tst = 0;
            do                                     //loop until a correct base is found
            {
                tst++;
                result = Math.Pow(2, tst);
            }
            while (result <= num);

            tstBase = (int)tst;
            usrNum = num;

            if (num % 2 == 0)                      //check for even #s
            {
                isOdd = false;
            }


            return true;

        }





        static void Main(string[] args)
        {

            double convNumber;

            Console.Write("please input a number for conversion >   ");
            string usrInput = Console.ReadLine();
            if (GetBase(usrInput, out int length, out double number, out bool isOdd))
            {
                convNumber = number;
                char[] output = new char[length];



                for (int j = 0; j <= length - 1; j++)
                {

                    double exp = length - 1 - j;

                    if (number - Math.Pow(2, exp) < 0) output[j] = '0';
                    else
                    {
                        output[j] = '1';
                        number -= Math.Pow(2, exp);
                    }



                }

                if (isOdd) output[length - 1] = '1';

                string binaryNum = new string(output);

                Console.WriteLine(string.Format("\t{0}", binaryNum));

                int position = 0;
                foreach (char digit in output)
                {
                    double exp = output.Length - 1 - position;
                    position++;

                    Console.Write(string.Format("{0,10} * 2 ^ {1} ({2})", digit, exp, Math.Pow(2, exp) * Int32.Parse(char.ToString(digit))));
                    if (position < output.Length) Console.Write(string.Format("\n{0,15:G}\n", "+"));


                    Thread.Sleep(1000);

                }
                Console.WriteLine(string.Format("\t= {0}", convNumber));
                return;
            }

            Console.WriteLine("error. unable to convert");

        }
    }
}
