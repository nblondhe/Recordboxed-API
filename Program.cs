
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Recordboxed.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var dbHost = builder.Configuration["RB:HOST"];
var serverName = builder.Configuration["RB:SERVERNAME"];
var dbName = builder.Configuration["RB:DBNAME"];
var productionConnectionString = builder.Configuration["ConnectionStrings:Recordboxed:AZSQLDB"];
builder.Services.AddSqlServer<DataContext>(productionConnectionString, options => options.EnableRetryOnFailure());

// builder.Services.AddDbContext<DataContext>(options => {
//     var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!
//     .Replace("{RB:HOST}", dbHost)
//     .Replace("{RB:SERVERNAME}", serverName)
//     .Replace("{RB:DBNAME}", dbName);
//     options.UseSqlServer(connectionString);
// });

var app = builder.Build();
app.Logger.LogInformation("=== LOGGING STARTED");

if (app.Environment.IsDevelopment())
{
    await using var scope = app.Services.CreateAsyncScope();
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    await context.Database.EnsureCreatedAsync();
    DbInitializer.Initialize(context);

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

