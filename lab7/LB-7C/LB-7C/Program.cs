using System;
using System.ServiceModel;
using LB_7C.ServiceHandler;

namespace LB_7C
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(PhoneContactService));
            host.Open();
            Console.WriteLine("Service is running");
            Console.WriteLine("Press enter to quit...");
            Console.ReadLine();
            host.Close();
        }
    }
}
