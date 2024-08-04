using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri("amqp://localhost:5672"), host =>
        {
            host.Username("guest");
            host.Password("guest");
        });
    });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

