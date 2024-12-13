using CodePulseAPI.Data;
using CodePulseAPI.Repositories.Implementation;
using CodePulseAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowFrontendOrigin", policy =>
//    {
//        policy.AllowAnyOrigin() //localhost:3000") // Replace with your frontend URL
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});



builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CodePulseConnetionString"));
});
builder.Services.AddScoped<IEventosRepository, EventosRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors("AllowFrontendOrigin");

//app.UseAuthorization();

app.UseCors(builder =>
    builder.WithOrigins("http://localhost:3000")
           .AllowAnyMethod()
           .AllowAnyHeader());

app.MapControllers();

app.Run();
