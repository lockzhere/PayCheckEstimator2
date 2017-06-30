﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCheckEstimator
{
    class Program
    {
        static double wage;
        static double oTime;
        static double oTimePay;
        static double stdTime;
        static double stdPay;
        static double holdingHours;
        static double net;
        static double gross;
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            //Get users current wages
            Console.Write("Enter Wages: ");
            wage = Convert.ToInt32(Console.ReadLine());

            // get users total week 1 hours
            Console.Write("Enter week 1 Hours: ");
            holdingHours = Convert.ToInt32(Console.ReadLine());

            // split hours 40/ot

            //Somewhere along here, entering a decimal point is throwing an exception. Fix it!

            if (holdingHours > 40)
            {
                oTime = oTime + (holdingHours - 40); // () should ensure we remove std hours first before adding to Otime
                stdTime = stdTime + 40; //              (this will be 40 if holdingHours is > 40)
                Console.WriteLine("if true; OT:{0}, std:{1}", oTime, stdTime);
            }

            else if (holdingHours <= 40)
            {
                stdTime = stdTime + holdingHours;
                Console.WriteLine("Entered Hours with no Overtime; w1 oTime: {0}, stdTime {1}", oTime, stdTime);
            }


            // get users total week 2 Hours

            Console.WriteLine("");
            Console.Write("Enter week 2 Hours: ");
            holdingHours = Convert.ToInt32(Console.ReadLine());

            // Split week 2 hours (40)/OT

            if (holdingHours > 40)
            {
                oTime = oTime + (holdingHours - 40); // Preserving original oTime, and adding new.
                stdTime = stdTime + 40; // Same as above.
                Console.WriteLine("Total oTime: {0}, Total stdTime: {1}", oTime, stdTime);
            }

            else if (holdingHours <= 40)
            {
                stdTime = stdTime + holdingHours;
                Console.WriteLine("Total oTime: {0}, Total stdTime: {1}", oTime, stdTime);
            }


            // Break apart user input from program calculations.
            Console.WriteLine(" ");
            Console.WriteLine("");

            stdPay = stdTime * wage;
            oTimePay = oTime * (wage * 1.5);
            gross = stdPay + oTimePay;
            net = stdPay + oTimePay - (oTimePay * 100 - 30) / 100;

            Console.WriteLine("Estimate paycheck based off of: {0} Standard Hours @ {1}, {2} Overtime hours at {3}", stdTime, wage, oTime, wage * 1.5);
            Console.WriteLine("Standard hours are paying: {0}", stdPay);
            Console.WriteLine("Overtime Hours are paying: {0}", oTimePay);
            

            Console.WriteLine("Estimated Paycheck values are; Gross: {0}, Net: {1}.", gross, net);
            double percent = PercInc(net, gross);
            Console.WriteLine("TEST: Percentage paid to taxes: {0}", percent);
            Console.ReadLine();
            CleanUp();
        }

        public static void ConsoleWrite(ConsoleColor color, string text)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = originalColor;
        }

        public static void CleanUp()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Thank you!\r\nPress a key to exit this program");
        }

        public static int PercInc(double low, double high)
        {
            double difference = high - low;
            double holding = difference / low;
            double percInc = holding * 100;
            return (int)percInc;

        }
    }
}
