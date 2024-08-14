using System.Net.Http.Json;
using System.Text.Json;

namespace ConsumerMessage;

public class ViaCepService : IViaCepService
{
    const string url = "viacep.com.br/ws";

    private readonly HttpClient _httpClient = new HttpClient();

    public async Task<EnderecoResponse> getEndereco(string cep)
    {
        var requestResponse = await _httpClient.GetAsync($"{url}/{cep}/json/");
        requestResponse.EnsureSuccessStatusCode();
        System.Console.WriteLine("", requestResponse.StatusCode);
        var response = JsonSerializer.Deserialize<EnderecoResponse>(requestResponse.ToString());
        System.Console.WriteLine("convertido para obj com sucesso!");
        return response;
    }
}
