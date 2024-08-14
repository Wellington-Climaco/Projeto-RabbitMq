using ProducerAPI.Worker.Response;

namespace ProducerAPI.Worker.Abstrations
{
    public interface IViaCepService
    {
        Task<ViaCepResponse> GetEndereco(string cep);
    }
}
