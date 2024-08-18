using System.ComponentModel.DataAnnotations;

namespace ProducerAPI;

public class ClienteRequest
{
    [Required(ErrorMessage = "Campo obrigatório")]
    [Length(3, 20, ErrorMessage = "Nome inválido")]   
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo obrigatório")]
    [Length(3, 20, ErrorMessage = "Nome inválido") ]  
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo obrigatório")]
    [StringLength(8, MinimumLength = 8, ErrorMessage = "Cep inválido")]
    public string Cep { get; set; } = string.Empty;
}
