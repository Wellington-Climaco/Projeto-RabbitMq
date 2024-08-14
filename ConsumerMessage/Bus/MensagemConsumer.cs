using MassTransit;
using ConsumerMessage.Entities;
using ConsumerMessage.Repository;
using ConsumerMessage;
using System.Diagnostics;

namespace ConsumerMessage;

public class MensagemConsumer : IConsumer<TextMensagem>
{
    private readonly ILocalizacaoService _localizacaoService;
    private readonly ClienteRepository _clienteRepo;

    public MensagemConsumer(ILocalizacaoService localizacaoService, ClienteRepository clienteRepo)
    {
        _localizacaoService = localizacaoService;
        _clienteRepo = clienteRepo;
    }

    public Task Consume(ConsumeContext<TextMensagem> context)
    {
        var timer = Stopwatch.StartNew();
        Console.WriteLine("Mensagem recebida",context.Message.mensagem);
        var dados = context.Message.mensagem;
        return Task.CompletedTask; 
        //var response = await _localizacaoService.VerificaLocalizacao(dados);

        // if(!response)
        // {
        //     Console.WriteLine("Desculpe, aceitamos somente clientes de São paulo");
        // }

        // var cliente = new Cliente(dados.FirstName,dados.LastName,dados.Email,dados.Cep);
        // await _clienteRepo.AddCliente(cliente);
    }
}
