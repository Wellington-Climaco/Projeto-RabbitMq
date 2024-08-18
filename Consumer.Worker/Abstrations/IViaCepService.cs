using Consumer.Worker.Response;

namespace Consumer.Worker.Abstrations
{
    public interface IViaCepService
    {
        Task<ViaCepResponse> GetEndereco(string cep);
    }
}
