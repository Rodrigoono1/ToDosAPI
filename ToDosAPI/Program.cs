using Microsoft.EntityFrameworkCore;
using ToDosAPI.Data;
using ToDosAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

//add DbConnection
///In-Memory Database creation
builder.Services.AddDbContext<ApiContext>(a=>a.UseInMemoryDatabase("ToDoDB"));
//builder.Services.AddSqlite<ApiContext>(builder.Configuration.GetConnectionString("DefaultConnection"));

///Add Dependency Injection for Services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IToDoService, ToDoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
