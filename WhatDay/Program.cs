using System;
using System.Collections.Generic;

namespace WhatDay
{
    // input: year month day
    // returns day's name
    //https://www.reddit.com/r/dailyprogrammer/comments/79npf9/20171030_challenge_338_easy_what_day_was_it_again/
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
                run();
        }

        private static void run()
        {
            string[] args = Console.ReadLine().Split(' ');
            string[] days = new string[] { "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            int year = Int32.Parse(args[0]);
            int dayOfMonth = Int32.Parse(args[2]);
            Dictionary<int, String> months = new Dictionary<int, string>()
            {
                { 3, "March" },
                { 4, "April" },
                { 5, "May" },
                { 6, "June" },
                { 7, "July" },
                { 8, "August" },
                { 9, "September" },
                { 10, "October" },
                { 11, "November" },
                { 12, "December" },
                { 13, "January" },
                { 14, "February" },
            };
            int month = Int32.Parse(args[1]);
            if (month < 3)
            {
                year--;
                month += 12;
            }
            int result =
                (   dayOfMonth +
                    ((int)Math.Floor((double)13 * (month + 1)) / 5) +
                    year +
                    (int)Math.Floor((double)year / 4) -
                    (int)(Math.Floor((double)year / 100)) +
                    (int)(Math.Floor((double)year / 400))  ) 
                    % 7;
            Console.WriteLine(days[result]);
        }
    }
}
