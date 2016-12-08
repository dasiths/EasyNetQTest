using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQTest.Models;

namespace ReceiverTest
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var bus = RabbitHutch.CreateBus("amqp://olnoebsz:RWYkFj0Ynx36b6MwmBmtn24wzaptjhYL@hyena.rmq.cloudamqp.com/olnoebsz"))
            {

                //bus.Receive<MessageTest>("my.queue", message => Console.WriteLine("MyMessage: {0}", message.message));
                Console.WriteLine("Type a topic to subscribe to:");
                var topic = Console.ReadLine();

                bus.Subscribe<MessageTest>($"my.queue.{topic}", message => Console.WriteLine("Recieved: {0}", message.message), x=> x.WithTopic(topic));

                Console.ReadLine();
            }

            

        }
    }
}
