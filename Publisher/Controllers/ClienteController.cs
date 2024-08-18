using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace ProducerAPI;

[ApiController]
public class ClienteController : ControllerBase
{
    private readonly IPublishEndpoint _publish;

    public ClienteController(IPublishEndpoint publish)
    {
        _publish = publish;
    }

    [HttpPost("cliente/add")]
    public async Task<IActionResult> CadastroCliente([FromBody] ClienteRequest dados)
    {
        await _publish.Publish(new ClienteAnaliseEvent(dados.FirstName, dados.LastName, dados.Email, dados.Cep));

        return Ok("Cadastro enviado para análise");
    }
}
