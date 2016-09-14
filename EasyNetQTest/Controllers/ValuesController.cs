using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EasyNetQTest.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            //using (var bus = RabbitHutch.CreateBus("amqp://hbfbcxxk:dA9pZPfa0hQZk8GVT54O5O-KmpIeFTXm@hyena.rmq.cloudamqp.com/hbfbcxxk"))
            //{

            IBus bus = WebApiApplication.BusConnection;

            for (int i = 0; i < 10; i++)
            {
                bus.Send("my.queue",
                    new Models.MessageTest(
                        string.Format("Message {0} time is {1}", i, DateTime.Now.ToLongTimeString())));
            }

            //}


            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
