using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Interfaces;
using Store.Middleware;
using Store.Services;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddTransient<IListProductsService, ListProductsService>();
builder.Services.AddTransient<IAddProductService, AddProductService>();
var app = builder.Build();

app.UseMiddleware<ListProductMiddleware>();
app.UseMiddleware<AddProductMiddleware>();

app.MapGet("/", () => "Hello World!");

app.Run();
