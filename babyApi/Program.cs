global  using babyApi.data;
global using Microsoft.EntityFrameworkCore;
using babyApi.data.Repositories;
using babyApi.domain;
using babyApi.services.Interfaces;
using babyApi.services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddTransient<IGenericRepository<Activity>, GenericRepository<Activity>>() ;
builder.Services.AddTransient<IGenericRepository<BabyActivity>, GenericRepository<BabyActivity>>();
builder.Services.AddTransient<IGenericRepository<BabyProfile>, GenericRepository<BabyProfile>>();
builder.Services.AddTransient<IGenericRepository<User>, GenericRepository<User>>();
builder.Services.AddScoped<IJWTService, JWTService>();


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
