using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyNetQTest.Models
{
    public class MessageTest
    {
        public string message { get; set; }

        public MessageTest(string msg)
        {
            message = msg;
        }
    }
}