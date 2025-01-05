using Netways.Unit6201.RabbitMQ.RabbitMQUtilities;
using Netways.Unit6201.RabbitMQ.Services;

namespace Netways.NetPays.UI
{
    public class RabbitMQConsumer : BackgroundService
    {
        private readonly IRabbitMQService _rabbitMqService;

        public RabbitMQConsumer(IRabbitMQService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _rabbitMqService.ReadMsgFromQueue("Sadad_Payments_Notification", HandleMessage, 110);
        }

        private FunctionResult HandleMessage(string message, string queueName)
        {
            try
            {
                Console.WriteLine($"Message {message} was read successfully from {queueName}");
                return FunctionResult.SucceededAndDeleteFromQueue;
            }
            catch (Exception)
            {
                return FunctionResult.FailedAndRequeue;
            }
        }
    }
}