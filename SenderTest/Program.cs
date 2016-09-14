using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQTest.Models;
using System.Threading;

namespace SenderTest
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var bus = RabbitHutch.CreateBus("amqp://hbfbcxxk:dA9pZPfa0hQZk8GVT54O5O-KmpIeFTXm@hyena.rmq.cloudamqp.com/hbfbcxxk"))
            {

                while (true)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        var message = new MessageTest(
                            string.Format("Message {0} is {1}", i, Guid.NewGuid().ToString()));
                        Console.WriteLine(message.message);
                        bus.SendAsync<MessageTest>("my.queue", message);
                        //Thread.Sleep(1000);
                    }
                    

                    if (Console.ReadLine().ToLower().Contains("q") == true)
                    {
                        break;
                    }
                }               

                
            }
        }
    }
}
