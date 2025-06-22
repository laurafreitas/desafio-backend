using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "mottu_user",
                Password = "mottu@1234",
                VirtualHost = "/"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "moto_criada",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var mensagem = Encoding.UTF8.GetString(body);
                Console.WriteLine($"📨 Evento recebido: {mensagem}");
            };

            channel.BasicConsume(
                queue: "moto_criada",
                autoAck: true,
                consumer: consumer
            );

            Console.WriteLine("👂 Aguardando eventos da fila 'moto_criada'. Pressione ENTER para sair.");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Erro: {ex.Message}");
        }
    }

}