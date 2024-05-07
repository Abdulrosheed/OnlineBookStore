using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Context;
using OnlineBookstore.Contracts;
using OnlineBookstore.Implementations;
using OnlineBookstore.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookStoreRepository,BookStoreRepository>();
builder.Services.AddScoped<IApplicationUnitOfWork,ApplicationUnitOfWork>();
builder.Services.AddScoped<IBookStoreService,BookStoreService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

