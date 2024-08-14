using ConsumerMessage.Repository;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsumerMessage
{
    internal class Program
    {
        static string connString = "Server=localhost,1433;Database=Usuarios;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciou");
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<ILocalizacaoService, LocalizacaoService>();
                    services.AddScoped<IViaCepService, ViaCepService>();
                    services.AddScoped<ClienteRepository>();
                    services.AddDbContext<ContextDb>(options => options.UseSqlServer(connString));
                    services.AddMassTransit(x =>
                    {
                        var asb = typeof(Program).Assembly;
                        x.AddConsumers(asb);

                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host(new Uri("amqp://localhost:5672"), host =>
                            {
                                host.Username("guest");
                                host.Password("guest");
                            });

                            cfg.ConfigureEndpoints(context);
                        });
                    });
                }).Build();
                Console.WriteLine("iniciou msm");
            host.Run();
        }
    }
}
