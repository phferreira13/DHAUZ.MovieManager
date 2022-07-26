using DHAUZ.MovieManager.Domain.Interface.Repositories;
using DHAUZ.MovieManager.Domain.Interface.Services;
using DHAUZ.MovieManager.Domain.Services;
using DHAUZ.MovieManager.Domain.Shared.Configuration;
using DHAUZ.MovieManager.HTTPClient.Clients;
using DHAUZ.MovieManager.HTTPClient.Interface;
using DHAUZ.MovieManager.Infra.Context;
using DHAUZ.MovieManager.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json");

var configuration = configurationBuilder.Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProjectContext>();
builder.Services.Configure<OmdbConfig>(configuration.GetSection("OmdbConfig"));
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IOmdbHttpClient, OmdbHttpClient>();

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
