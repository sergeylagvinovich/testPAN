using Microsoft.EntityFrameworkCore;
using Quartz;
using testPAN;
using testPAN.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InitializeRepo();
builder.Services.InitializeServices();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDataBase>(options =>
    options.UseSqlServer(connection));

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

Initialize.InitializeSheduler(app, app.Services.GetRequiredService<IScheduler>());


app.Run();
