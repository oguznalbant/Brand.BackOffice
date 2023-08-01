using Brand.AdvertManagement.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCap(a =>
{
    try
    {
        Console.WriteLine("rabbit connection started");
        Console.WriteLine(new Uri(builder.Configuration.GetValue<string>("RabbitSettings:ConnectionString")).ToString());
        a.FailedRetryCount = 0;
        a.UseRabbitMQ(r =>
        {
            r.ConnectionFactoryOptions = o =>
            {
                o.Ssl.Enabled = false;
                o.Uri = new Uri(builder.Configuration.GetValue<string>("RabbitSettings:ConnectionString"));
                //o.UserName = builder.Configuration.GetValue<string>("RabbitSettings:UserName");
                //o.Password = builder.Configuration.GetValue<string>("RabbitSettings:Password");
                //o.Port = builder.Configuration.GetValue<int>("RabbitSettings:Port");
            };
        });
        a.UseInMemoryStorage();
        a.UseDashboard();
        Console.WriteLine("rabbit connection finished");
    }
    catch (Exception ex)
    {
        Console.WriteLine(new Uri(builder.Configuration.GetValue<string>("RabbitSettings:ConnectionString")).ToString());
        throw;
    }

});

builder.Services.AddAutoMapper(typeof(Program));

/* Service Registrations */
builder.Services.AddScoped<IAdvertRepository, AdvertRepository>();
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
