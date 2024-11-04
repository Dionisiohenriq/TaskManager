using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Extensions;
using TaskManager.Infra.Data;
using TaskManager.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(con =>
    con.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(pol => pol.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
builder.Services.RegisterServices();

var app = builder.Build();

// Error handling
app.HandleErrors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add Database
{
    var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

app.UseCors();
app.UseHttpsRedirection();

app.Run();