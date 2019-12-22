using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static string timeConversion(string s)
        {
            //Format = hh:mm:ssAM/PM
            
            //Split by hours, minute, seconds.
            string[] words = s.Split(':');

            //Words 0 - Hours
            //Words 1 - Min
            //Words 2 - Second/Am or PM

            //For seconds see if it contains letters AM or PM
            if (words[2].Contains("AM"))
            {
                if (words[0] == "12") //If AM, convert when hour is 12 to 00.
                { 
                    words[0] = "00";
                }
            }
            else if(words[2].Contains("PM"))
            {
                if (words[0] != "12") //If PM, convert when hour is 1:00:00 and later to add 12. Ex. 2PM, 12+2 = 14:00:00
                { 
                    int hour = int.Parse(words[0]) + 12;
                    words[0] = hour.ToString();
                }
            }

            //Remove AM or PM
            words[2] = Regex.Match(words[2], @"\d+").Value;

            return string.Join(":", words);
        }

        static void Main(string[] args)
        {
            string [] s = { "12:25:10PM", "12:10:00AM" , "1:59:59PM"};

            foreach (string c in s)
            {
                System.Console.WriteLine($"Standard Time: {c}");
                System.Console.WriteLine($"Military Time: {timeConversion(c)}\n");
            }

        }
    }
}
