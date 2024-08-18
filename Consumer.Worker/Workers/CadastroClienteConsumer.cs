using Consumer.Worker.Abstrations;
using Consumer.Worker.Database;
using Consumer.Worker.Entities;
using Contracts;
using MassTransit;

namespace Consumer.Worker.Workers
{
    public class CadastroClienteConsumer : IConsumer<ClienteAnaliseEvent>
    {
        private readonly ILogger<TratamentoMensagemFilaConsumer> _logger;
        private readonly IViaCepService _viaCepService;
        private readonly AppDbContext _appDbContext;

        public CadastroClienteConsumer(ILogger<TratamentoMensagemFilaConsumer> logger, IViaCepService viaCepService, AppDbContext appDbContext)
        {
            _logger = logger;
            _viaCepService = viaCepService;
            _appDbContext = appDbContext;
        }
        public async Task Consume(ConsumeContext<ClienteAnaliseEvent> context)
        {
            var cep = context.Message.Cep;
            _logger.LogInformation($"cep: {cep}");

            var endereco = await _viaCepService.GetEndereco(cep);

            if (endereco.uf.Contains("SP"))
            {
                var cliente = new Cliente { FirstName = context.Message.FirstName, LastName = context.Message.LastName,
                    Cep = context.Message.Cep,Email = context.Message.Email,Uf = endereco.uf };

                await _appDbContext.AddAsync(cliente);
                await _appDbContext.SaveChangesAsync();
                Console.WriteLine(cliente);              
            }
            else
            {
                Console.WriteLine("cliente não foi gravado");
            }          
        }
    }
}
