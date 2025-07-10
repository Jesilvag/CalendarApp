using Calendar.Application;
using Calendar.Infrastructure;
using Calendar.Web.Api;
using Calendar.Web.Components;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using System;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRefitClient<IEventsApi>()
    .ConfigureHttpClient(c =>
    {
        var baseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl") ?? throw new InvalidOperationException("API base URL is not configured.");
        c.BaseAddress = new Uri(baseUrl);
    });
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
