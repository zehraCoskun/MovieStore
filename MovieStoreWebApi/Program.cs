using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//dbContext ekleme
builder.Services.AddDbContext<MovieStoreDBContext>(opt=> opt.UseInMemoryDatabase(databaseName : "MovieStoreDB"));
builder.Services.AddScoped<IMovieStoreDBContext, MovieStoreDBContext>();

//auto mapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); 

var app = builder.Build();


//Uygulama ayağa kalktığından initial datanın in memory DB'ye yazılması için
using (var scope = app.Services.CreateScope()) 
        { var services = scope.ServiceProvider; 
          DataGenerator.Initialize(services); }


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
