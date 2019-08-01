using ApiSite.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace ApiSite.Services
{
    public class Fila
    {
        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private string _queueName;

        public Fila(string queueName)
        {
            _connectionFactory = GetConnectionFactory();
            _connection = CreateConnection(_connectionFactory);
            _queueName = queueName;
            CreateQueue(_queueName, _connection);
        }

        protected ConnectionFactory GetConnectionFactory()
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",
                Port = 5672
            };
            return connectionFactory;
        }

        protected IConnection CreateConnection(ConnectionFactory connectionFactory)
        {
            return connectionFactory.CreateConnection();
        }

        protected QueueDeclareOk CreateQueue(string queueName, IConnection connection)
        {
            QueueDeclareOk queue;
            using (var channel = connection.CreateModel())
            {
                queue = channel.QueueDeclare(queueName, false, false, false, null);
            }
            return queue;
        }

        public bool WriteMessageOnQueue(DadosPagina dadosPagina)
        {
            byte[] messagebuffer = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dadosPagina));

            using (var channel = _connection.CreateModel())
            {
                channel.BasicPublish(string.Empty, _queueName, null, messagebuffer);// Encoding.ASCII.GetBytes("teste"));
            }

            return  true;
        }

        public string RetrieveSingleMessage()
        {
            BasicGetResult data;
            using (var channel = _connection.CreateModel())
            {
                data = channel.BasicGet(_queueName, true);
            }
            return data != null ? System.Text.Encoding.UTF8.GetString(data.Body) : null;
        }

        public DadosPagina ReturnMessage()
        {
            BasicGetResult data;
    
            using (var channel = _connection.CreateModel())
            {
                data = channel.BasicGet(_queueName, true);              
            }
            return data != null ? JsonConvert.DeserializeObject<DadosPagina>(Encoding.UTF8.GetString(data.Body)) : null;
        }


    }
}
