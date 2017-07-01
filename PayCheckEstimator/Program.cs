﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCheckEstimator
{
    class Program
    {
        static double wage, oTime, oTimePay, stdTime, stdPay, holdingHours, net, gross = 0;
        static int week = 0;


        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            //Get users current wages

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Wages: ");
            //wage = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            wage = Convert.ToDouble(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            GetHours();
            GetHours();

            // Break apart user input from program calculations.
            Console.WriteLine(" ");
            Console.WriteLine("");

            stdPay = stdTime * wage;
            oTimePay = oTime * (wage * 1.5);
            gross = stdPay + oTimePay;
            net = gross * (100-33.5)/100;

            Console.WriteLine("Estimate paycheck based off of: {0} Standard Hours @ {1}, {2} Overtime hours at {3}", stdTime, wage, oTime, wage * 1.5);
            Console.WriteLine("Standard hours are paying: {0}", stdPay);
            Console.WriteLine("Overtime Hours are paying: {0}", oTimePay);
            

            Console.WriteLine("Estimated Paycheck values are; Gross: {0}, Net: {1}.", gross, net);
            double percent = PercDec(net, gross);


            Console.WriteLine("TEST: Percentage paid to taxes: {1}%", Console.ForegroundColor = ConsoleColor.Gray, percent);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            CleanUp();
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
            Console.WriteLine("Enter week {0} hours: ", week);
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
    }
}
