# EasyNetQPublisher_DotNetCoreAPI

EasyNetQ is the leading open-source client API for RabbitMQ on .NET. 
RabbitMQ is a widely used open-source message broker that helps in scaling the application by deploying a message queuing mechanism in between the two applications. It offers temporary storage for data preventing data loss. RabbitMQ Queue takes messages from the publisher and sends them to the consumer.
This application contains a .NET Core 6 API. Which is responsible for sending messages (data) to RabbitMQ by using EasyNetQ. Since the API is responsible for sending mesages to RabbitMQ therefore, we call it as Publisher.

# Note: Install RabbitMQ before running this solution if RabbitMQ is not installed yet.

Steps:
1- Open RabbitMQ client GUI on browser by hitting http://localhost:15672/
2- Login to RabbitMQ interface.
3- Goto Admin Tab-->Users-->Add a User--> Create a user with name "test" and password "test"
4- Goto Admin Tab-->Virtaul Hosts-->add a new virtual host with name "test"
5- Run the EasyNetQueueExample.PublisherAPI solution
5- Send a message by executing "publishmessage" from swagger


# EasyNetQ Consumer Solution can be found here
https://github.com/NajibbUllah/-EasyNetQConsumer_DotNetCoreAPI

