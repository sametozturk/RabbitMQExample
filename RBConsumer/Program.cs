
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory=new ConnectionFactory();
factory.HostName="localhost";

var connection=factory.CreateConnection();
var channel=connection.CreateModel();

var consumer=new EventingBasicConsumer(channel);
consumer.Received +=(model,ea)=>{
    var byteMessage=ea.Body.ToArray();
    var message=Encoding.UTF8.GetString(byteMessage);
    Console.WriteLine(message);
};

channel.BasicConsume(queue:"hello",autoAck:true,consumer:consumer);

Console.ReadKey();