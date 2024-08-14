namespace ConsumerMessage;

public class LocalizacaoService : ILocalizacaoService
{
    private readonly IViaCepService _viaCepService;

    public LocalizacaoService(IViaCepService viaCepService)
    {
        _viaCepService = viaCepService;
    }

    public async Task<bool> VerificaLocalizacao(ClienteEvent clienteEvent)
    {
        var response =  await _viaCepService.getEndereco(clienteEvent.Cep);

        var uf = response.uf;

        if(uf.Equals("SP"))
        {
            Console.WriteLine("cliente é de SP!");
            return true;      
        }

        Console.WriteLine("cliente não é de SP!");
        return false;

    }
}
