using Microsoft.EntityFrameworkCore;
using RevConnectAPI.Database.DataAccess;
using RevConnectAPI.Logic;
using Microsoft.Extensions.DependencyInjection;
using RevConnectAPI.Database.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RevConnectAPIContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("RevConnectAPIContext") ?? throw new InvalidOperationException("Connection string 'RevConnectAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RevConnectAPIContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddSingleton<IRepository>(sp => new SqlRepository("connectionString", sp.GetRequiredService<ILogger<SqlRepository>>()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
