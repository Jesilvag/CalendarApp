using Calendar.Api.Profiles;
using Calendar.Application;
using Calendar.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices("CalendarDb");
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opts =>
{
    opts.AddPolicy("WebClient", p =>
        p.WithOrigins(builder.Configuration["WebClientUrl"] ?? "https://localhost:5002")
         .AllowAnyMethod()
         .AllowAnyHeader());
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("WebClient");

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
