namespace _02.PubNubChat
{
    using PubNubMessaging.Core;
    using System;
    using System.Net;
    using System.Net.Sockets;

    class Startup
    {
        static void Main(string[] args)
        {
            // Instantiate PubNub
            Pubnub pubnub = new Pubnub(
               publishKey: "pub-c-10be8ced-10af-4b39-a2d7-3266a64107cc",
               subscribeKey: "sub-c-7163716c-8c6b-11e5-9320-02ee2ddab7fe"
            );

            string channel = "chat";

            // Subscribe to the demo_tutorial channel
            pubnub.Subscribe<string>(
               channel,
               DisplaySubscribeReturnMessage,
               DisplaySubscribeConnectStatusMessage,
               DisplayErrorMessage);

            // Publish a simple message to the demo_tutorial channel
            pubnub.Publish<string>(
               channel,
               "Subscribed to channel",
               DisplayReturnMessage,
               DisplayErrorMessage);

            while (true)
            {
                var msg = Console.ReadLine();
                pubnub.Publish<string>(
                   channel,
                   msg,
                   DisplayReturnMessage,
                   DisplayErrorMessage);

                Console.SetCursorPosition(0, Console.CursorTop - 1);
                ClearCurrentConsoleLine();
            }
        }

        private static void DisplayReturnMessage(string obj)
        {     
            //Console.WriteLine(obj);
        }

        private static void DisplayErrorMessage(PubnubClientError obj)
        {
            Console.WriteLine(obj.Message);
        }

        private static void DisplaySubscribeConnectStatusMessage(string obj)
        {
            Console.WriteLine(obj);
        }

        private static void DisplaySubscribeReturnMessage(string obj)
        {
            var msg = obj.Split(new char[] { '[', ']', '"', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var ip = GetLocalIPAddress();
            Console.WriteLine("{0}: {1}", ip, msg[0]);
        }

        private static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        private static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}
