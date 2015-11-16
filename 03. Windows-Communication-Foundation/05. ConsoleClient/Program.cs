namespace _05.ConsoleClient
{
    using ConsoleClient.SubstringServiceReference;
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            SubstringServiceClient client = new SubstringServiceClient();
            using (client)
            {
                var result = client.GetOccurrencesCount("goshko", "goshko e pich, goshko ne e pich");
                Console.WriteLine(result);
            }
        }
    }
}
