using Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProducerAPI.Worker.Workers
{
    public class TratamentoMensagemFilaConsumer : IConsumer<MessageEvent>
    {
        private readonly ILogger<TratamentoMensagemFilaConsumer> _logger;

        public TratamentoMensagemFilaConsumer(ILogger<TratamentoMensagemFilaConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<MessageEvent> context)
        {
            var mensagem = context.Message.Msg;

            _logger.LogInformation($"{mensagem}");

            return Task.CompletedTask;
        }
    }
}
