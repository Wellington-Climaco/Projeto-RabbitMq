using System;

namespace ConsumerMessage.Repository;

public class ClienteRepository
{
    private readonly ContextDb _dataContext;

    public ClienteRepository(ContextDb dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddCliente(Cliente cliente)
    {
        await _dataContext.AddAsync(cliente);
        await _dataContext.SaveChangesAsync();
    }
}
