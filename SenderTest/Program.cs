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

            using (var bus = RabbitHutch.CreateBus("amqp://olnoebsz:RWYkFj0Ynx36b6MwmBmtn24wzaptjhYL@hyena.rmq.cloudamqp.com/olnoebsz"))
            {
                bool isFinished = false;

                while (isFinished==false)
                {

                    Console.WriteLine("Type a message to publish or quit to exit:");
                    var input = Console.ReadLine();

                    if (input == "quit")
                    {
                        isFinished = true;
                    }
                    else
                    {
                        var message = new MessageTest(input);

                        Console.WriteLine("Please enter a topic:");
                        var topic = Console.ReadLine();

                        //bus.SendAsync<MessageTest>("my.queue", message);
                        bus.Publish(message, topic);
                        //Thread.Sleep(1000);
                    }
                }


            }
        }
    }
}
