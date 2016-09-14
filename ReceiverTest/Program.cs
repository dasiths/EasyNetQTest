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

            using (var bus = RabbitHutch.CreateBus("amqp://hbfbcxxk:dA9pZPfa0hQZk8GVT54O5O-KmpIeFTXm@hyena.rmq.cloudamqp.com/hbfbcxxk"))
            {

                bus.Receive<MessageTest>("my.queue", message => Console.WriteLine("MyMessage: {0}", message.message));
                Console.ReadLine();
            }

            

        }
    }
}
