namespace _02.DayOfWeekService.ConsoleClient
{
    using DayOfWeekServiceReference;
    using System;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            // In order to see cyrilic letters change the console font to: consolas
            DayOfWeekServiceClient client = new DayOfWeekServiceClient();
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine(client.GetDayOfWeek(DateTime.Now)); 
        }
    }
}
