using ProducerAPI.Worker.Abstrations;
using ProducerAPI.Worker.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProducerAPI.Worker.Service
{
    internal class ViaCepService : IViaCepService
    {

        private static readonly HttpClient _HttpClient = new HttpClient() { BaseAddress = new Uri("https://viacep.com.br/ws/") };



        public async Task<ViaCepResponse> GetEndereco(string cep)
        {
            var requestResponse = await _HttpClient.GetAsync($"{cep}/json/");
            requestResponse.EnsureSuccessStatusCode();
            System.Console.WriteLine($"{requestResponse.StatusCode.ToString()}");
            var jsonResponse = await requestResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<ViaCepResponse>(jsonResponse);
            System.Console.WriteLine("convertido para obj com sucesso!");
            return response;
        }
    }
}
