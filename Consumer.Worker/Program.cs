using Consumer.Worker.Abstrations;
using Consumer.Worker.Database;
using Consumer.Worker.Service;
using Consumer.Worker.Workers;
using MassTransit;
using Microsoft.EntityFrameworkCore;
namespace Consumer.Worker
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
                    cfg.Host(new Uri("amqp://rabbitmq-pub-sub:5672"), host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    cfg.ConfigureEndpoints(ctx);
                });
            });

            var host = builder.Build();

            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.Migrate();
            }
            
            host.Run();
        }
    }
}