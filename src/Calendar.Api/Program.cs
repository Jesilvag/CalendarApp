using Calendar.Api.Components;
using Calendar.Application;
using Calendar.Infrastructure;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddBlazorBootstrap();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("DefaultConnection") ?? "CalendarDb");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

await app.RunAsync();
