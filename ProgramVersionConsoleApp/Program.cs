using System;

namespace ProgramVersionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var dateTime1970 = new DateTime(1970, 01, 01, 0, 0, 0);
            DateTime dateTimeNow = DateTime.Now;
            var dateTimeCuDateTime = new DateTime(dateTimeNow.Year, 01, 01, 0, 0, 0);
            Console.WriteLine($"5.{dateTimeNow.Year-dateTime1970.Year}.{Math.Round((dateTimeNow - dateTimeCuDateTime).TotalHours, 0)} ");
        }
    }
}
