using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory=new ConnectionFactory();
factory.HostName="localhost";

var connection=factory.CreateConnection();

var channel=connection.CreateModel();

var queueName=channel.QueueDeclare().QueueName; //rastgele queue name i vericek.

channel.QueueBind(queue:queueName,exchange:"logs",routingKey:string.Empty); //exchange e bind ettim. yani logs a bağladım.

var consumer=new EventingBasicConsumer(channel);
consumer.Received+=(model,ea)=>{
    var body=ea.Body.ToArray();
    var message=Encoding.UTF8.GetString(body);
    System.Console.WriteLine("okunan mesaj" + message);
};

channel.BasicConsume(queue:queueName,autoAck:false,consumer:consumer);

Console.ReadKey();

