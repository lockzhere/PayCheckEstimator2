using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCheckEstimator
{
    class Program
    {
        static double wage, shopWage, oWage, oShop, shopTime, oTime, oTimePay, stdTime, stdPay, holdingHours, net, gross = 0;
        static int week = 0;


        static void Main(string[] args)
        {

            GatherWages();

            GetHours();
            GetHours();

            Break();

            Calc();

            Console.WriteLine("Estimate paycheck based off of: {0} Standard Hours at ${1}, {2} Overtime hours at ${3}", stdTime, wage, oTime, oWage);
            Console.WriteLine("Standard hours are paying: {0}", stdPay);
            Console.WriteLine("Overtime Hours are paying: {0}", oTimePay);
            

            Console.WriteLine("Estimated Paycheck values are; Gross: ${0}, Net: ${1}.", gross, net);
            double percent = PercDec(net, gross);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Estimated percentage paid to taxes: ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("{0}%", percent);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            CleanUp();
        }

        public static void Calc()
        {
            stdPay = stdTime * wage;
            oTimePay = oTime * (wage * 1.5);
            gross = stdPay + oTimePay;
            net = gross * (100 - 30) / 100;
        }

        public static void CleanUp()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Thank you!\r\nPress a key to exit this program");
        }

        public static double PercDec(double low, double high)
        {
            // Double check calculation for percentage, just to be sure we didn't fuck anything up.
            // also, to work on passing values through seperate methods. (IE, not sure if i need double. but it return the percents i originally used)
            double percInc = ((high - low) / high) * 100; //re-worked this down to a single line compared to seperating operations into different variables

            return (double)percInc;

        }

        public static void GetHours()
        {
            week++; //since week is set as 0 at the beginning, we need to add one (first call) for week one(1), and add 1 again to get week two(2)
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter week {0} hours: ", week);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            holdingHours = Convert.ToDouble(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            if (holdingHours > 40)
            {
                oTime = oTime + (holdingHours - 40); // Preserving original oTime, and adding new.
                stdTime = stdTime + 40; // Same as above.
                

            }

            else if (holdingHours <= 40)
            {
                stdTime = stdTime + holdingHours;
                
            }
        }

        public static void GatherWages() // Main information gathering from user (stdWage, stdShop, hours, etc...)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;      //
            Console.Write("Enter Standard Wages: ");              // Gather standard wages. will be used to calculate oWage
            Console.ForegroundColor = ConsoleColor.DarkYellow;  //
            wage = Convert.ToDouble(Console.ReadLine());        //
            oWage = wage * 1.5;

            Console.ForegroundColor = ConsoleColor.Yellow;      //
            Console.Write("Enter shop wages: ");                  // Gather Shoptime wages, will be used to calculate shop pay and shop OT (if applicable)
            Console.ForegroundColor = ConsoleColor.DarkYellow;  //
            shopWage = Convert.ToDouble(Console.ReadLine());    //
            oShop = shopWage * 1.5;
        }

        public static void Break()
        {
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}
