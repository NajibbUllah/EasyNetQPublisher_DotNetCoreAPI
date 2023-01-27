using EasyNetQ;
using EasyNetQ.Topology;
using EasyNetQueueExample.PublisherAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyNetQueueExample.PublisherAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/easynetqpublisher")]
    [ApiController]
    public class EasyNetQPublisherController : ControllerBase
    {
        private readonly IBus bus;
        private readonly IConfiguration configuration;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="configuration"></param>
        public EasyNetQPublisherController(IBus bus, IConfiguration configuration)
        {
            this.bus = bus;
            this.configuration = configuration;
        }


        /// <summary>
        /// Publish Message to RabbitMQ using EasyNetQ 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("publishmessage")]
        public string PublishMessage()
        {
            //Getting QueueName and ExachangeName from AppSettings
            string queueName = configuration.GetValue<string>("RabbitMqQueueName");
            string exchangename = configuration.GetValue<string>("RabbitMqExchangeName");
           
            //Initializing Routing key
            string routingKey = queueName;

            //Declaring Queue
            var queue = bus.Advanced.QueueDeclare(queueName);

            //Declaring Exchange with  ExchangeType.Direct
            var exchange = bus.Advanced.ExchangeDeclare(exchangename, ExchangeType.Direct);

            //Binding Queue onto Exchange
            bus.Advanced.Bind(exchange, queue, routingKey);
            
            //My Message
            var message = new PublishMessageDto()
            {
                Id = 1,
                Name = "Najeeb Khan",
                MobileNo = "03023698567",
                Email ="najibb.khan@gmail.com",
                Message = "This is my fist EasyNetQ implementation example"
            };

            //Seriliazing PublishMessageDto onto EsayNetQ Message
            Message<PublishMessageDto> msg = new Message<PublishMessageDto>(message);

            //Publish the Message to Queue
            bus.Advanced.Publish(exchange, routingKey, true, msg);

            return "Success";
        }
    }
}
