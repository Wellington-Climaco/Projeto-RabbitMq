namespace ProducerAPI;

public class Cliente
{
    public Cliente(string firstName,string lastName, string email, string cep)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Cep = cep;
    }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Cep { get; set; } = string.Empty;
    
}
