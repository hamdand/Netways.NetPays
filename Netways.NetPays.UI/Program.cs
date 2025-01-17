using Netways.NetPays.UI;
using Netways.NetPays.UI.Components;
using Netways.Unit6201.RabbitMQ.RabbitMQUtilities;
using Netways.Unit6201.RabbitMQ.Services;
using Radzen;
using RedisFusion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.Configure<RabbitMQConfigurations>(
    builder.Configuration.GetSection(nameof(RabbitMQConfigurations)));
builder.Services
    .AddSingleton<IRabbitMQService, RabbitMQService>()
    .AddHostedService<RabbitMQConsumer>();

// Register register RedisFusionService
builder.Services.AddRedisFusionService(builder.Configuration);


builder.Services.AddHttpClient();
builder.Services.AddRadzenComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseRedisFusionOutputCache(); // Use Output Redis

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
