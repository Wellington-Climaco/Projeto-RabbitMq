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
    public async Task<IActionResult> CadastroCliente([FromBody] ClienteRequest cliente)
    {

        var clienteEvent = new ClienteEvent(cliente.FirstName, cliente.LastName, cliente.Email, cliente.Cep);

        await _publish.Publish(clienteEvent);

        return Ok("Cadastro enviado para análise");
    }
}
