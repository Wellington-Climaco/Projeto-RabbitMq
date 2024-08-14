namespace ConsumerMessage;

public interface ILocalizacaoService
{
    Task<bool> VerificaLocalizacao(ClienteEvent clienteEvent);
}
