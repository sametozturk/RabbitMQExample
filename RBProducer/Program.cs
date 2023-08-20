

using System.Text;
using RabbitMQ.Client;

var connactionFactory=new ConnectionFactory(){
    HostName="localhost"
};

var connection=connactionFactory.CreateConnection();
var channel=connection.CreateModel();

channel.QueueDeclare(queue:"hello",durable:false,exclusive:false,autoDelete:false,arguments:null);

var message="Hello RabbitMQ";

var byteMessage=Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange:"",routingKey:"hello",basicProperties:null,body:byteMessage);

Console.WriteLine("Mesaj gönderildi");

Console.ReadKey();