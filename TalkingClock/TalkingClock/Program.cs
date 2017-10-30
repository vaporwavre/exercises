using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalkingClock
{
    //Challenge: https://www.reddit.com/r/dailyprogrammer/comments/6jr76h/20170627_challenge_321_easy_talking_clock/
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
                run();
        }

        public static void run()
        {
            StringBuilder result = new StringBuilder("It's ");
            String time = Console.ReadLine();
            String[] words = time.Split(':');
            String[] hours = { "twelve", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve" };
            String[] minutesTen = { "ten", "twenty", "thirty", "forty", "fifty" };
            String[] minutesTeen = { "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            Boolean AM = true;

            int hour = Convert.ToInt32(words[0]);
            int minute = Convert.ToInt32(words[1]);
            int firstMinuteDigit = Convert.ToInt32(words[1].Substring(0, 1));
            int secondMinuteDigit = Convert.ToInt32(words[1].Substring(1, 1));

            if (hour >= 12)
                AM = false;

            if(hour < 13)
            {
                result.Append(hours[hour]);
            }
            else
            {
                result.Append(hours[hour - 12]);
            }

            if(minute > 0)
            {
                if(minute == 10)
                {
                    result.Append(" ten");
                }
                else if(minute > 10 && minute < 20)
                {
                    result.Append(" " + minutesTeen[secondMinuteDigit]);
                }
                else if(firstMinuteDigit == 0)
                {
                    result.Append(" oh " + hours[secondMinuteDigit]);
                }
                else
                {
                    result.Append(" " + minutesTen[firstMinuteDigit-1] + " " + hours[secondMinuteDigit]);
                }

            }

            if (AM)
            {
                result.Append(" AM");
            }
            else
            {
                result.Append(" PM");
            }

            Console.WriteLine(result.ToString());
        }
    }
}
