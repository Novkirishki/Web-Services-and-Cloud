namespace _01.ChatB
{
    using IronMQ;
    using IronMQ.Data;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class Startup
    {
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

        private static async Task<string> GetInputAsync()
        {
            return await Task.Run(() => Console.ReadLine());
        }

        private static async void SendMsg(Queue queue)
        {
            Task<string> getInput = GetInputAsync();
            // independent work which doesn't need the result of LongRunningOperationAsync can be done here

            //and now we call await on the task 
            string msg = await getInput;
            //use the result 
            queue.Push(GetLocalIPAddress() + ": " + msg);
        }

        public static void Main()
        {
            Client client = new Client("5649aff573d0cd00060000be", "CxkKy2oQPPvMfD9kQvW9");
            Queue receiveQueue = client.Queue("B");
            Queue sendQueue = client.Queue("A");

            Console.WriteLine("Listening for new messages from IronMQ server:");
            while (true)
            {
                Message msgReceive = receiveQueue.Get();
                if (msgReceive != null)
                {
                    Console.WriteLine(msgReceive.Body);
                    receiveQueue.DeleteMessage(msgReceive);
                }

                SendMsg(sendQueue);
            }
        }
    }
}
