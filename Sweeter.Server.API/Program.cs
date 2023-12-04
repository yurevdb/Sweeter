using Sweeter.Server.API;
using Sweeter.Server.Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ContactRepository, ContactDatabase>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetAssembly(typeof(Entrypoint))));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.AddServerUtilityAPI();
app.AddCrmAPI();

app.Run();
