namespace ConsumerMessage;

public interface IViaCepService
{
    Task<EnderecoResponse> getEndereco(string cep);
}
