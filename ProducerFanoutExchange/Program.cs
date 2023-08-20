using System.Text;
using RabbitMQ.Client;

var factory=new ConnectionFactory();
factory.HostName="localhost";

var connection=factory.CreateConnection();

var channel=connection.CreateModel();

channel.ExchangeDeclare(exchange:"logs",type:ExchangeType.Fanout);

var message=GetMessage(args);
var body=Encoding.UTF8.GetBytes(message);

channel.BasicPublish(exchange:"logs",routingKey:string.Empty,basicProperties:null,body:body);

System.Console.WriteLine("Mesaj gönderildi");

static string GetMessage(string[] args){
    return args.Length>0?string.Join(" ",args) : "info hello world";
}