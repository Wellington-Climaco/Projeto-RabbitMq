﻿namespace Consumer.Worker.Response
{
    public class ViaCepResponse
    {
        public string cep { get; set; } = string.Empty;
        public string logradouro { get; set; } = string.Empty;
        public string complemento { get; set; } = string.Empty;
        public string unidade { get; set; } = string.Empty;
        public string bairro { get; set; } = string.Empty;
        public string localidade { get; set; } = string.Empty;
        public string uf { get; set; } = string.Empty;
        public string ibge { get; set; } = string.Empty;
        public string gia { get; set; } = string.Empty;
        public string ddd { get; set; } = string.Empty;
        public string siafi { get; set; } = string.Empty;
    }
}
