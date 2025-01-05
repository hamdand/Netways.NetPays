using Netways.NetPays.UI.Models;
using Netways.Unit6201.RabbitMQ.RabbitMQUtilities;
using Netways.Unit6201.RabbitMQ.Services;
using Newtonsoft.Json;
using RedisFusion.Services;

namespace Netways.NetPays.UI
{
    public class RabbitMQConsumer : BackgroundService
    {
        private readonly IRabbitMQService _rabbitMqService;
        private readonly IRedisFusionService _redisService;

        public RabbitMQConsumer(IRabbitMQService rabbitMqService, IRedisFusionService redisService)
        {
            _rabbitMqService = rabbitMqService;
            _redisService = redisService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _rabbitMqService.ReadMsgFromQueueAsync("Sadad_Payments_Notification", HandleMessage, 110);
        }

        private async Task<FunctionResult> HandleMessage(string message, string queueName)
        {
            try
            {
                var payment = JsonConvert.DeserializeObject<PaymentNotification>(message);

                var result = await _redisService.GetOrAddCachedObjectAsync(payment.BillNumber, () => getData(payment));

                return FunctionResult.SucceededAndDeleteFromQueue;
            }
            catch (Exception)
            {
                return FunctionResult.FailedAndRequeue;
            }
        }

        private async Task<object> getData(PaymentNotification payment)
        {
            return payment;
        }
    }
}