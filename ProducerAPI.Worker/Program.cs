using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProducerAPI.Worker.Abstrations;
using ProducerAPI.Worker.Database;
using ProducerAPI.Worker.Service;
using ProducerAPI.Worker.Workers;
namespace ProducerAPI.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            builder.Services.AddScoped<IViaCepService,ViaCepService>();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                //x.AddConsumer<TratamentoMensagemFilaConsumer>();
                x.AddConsumer<CadastroClienteConsumer>();
             
                x.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(new Uri("amqp://localhost:5672"), host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    cfg.ConfigureEndpoints(ctx);
                });
            });

            var host = builder.Build();
            host.Run();
        }
    }
}