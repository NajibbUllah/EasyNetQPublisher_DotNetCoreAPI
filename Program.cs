using EasyNetQ;



var builder = WebApplication.CreateBuilder(args);

//Getting Configurations from appsettings.json
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

//Declaring EasyNetQ IBus
IBus bus = RabbitHutch.CreateBus(configuration.GetConnectionString("RabbitMQConnectionString"));

//Injecting IBus as Singleton Service
builder.Services.AddSingleton(bus);

//builder.Services.RegisterServices();
builder.Services.AddSingleton(configuration);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
