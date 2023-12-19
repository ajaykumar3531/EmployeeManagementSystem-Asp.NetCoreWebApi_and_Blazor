using EMS.BusinessLayer.Implementations;
using EMS.BusinessLayer.Interfaces;
using EMS.DataAccessLayer.Entities;
using EMS.DataAccessLayer.Interfaces;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmsContext>();
builder.Services.AddScoped(typeof(IEMSDataAccess<>), typeof(EMSDataAccess<>));
builder.Services.AddScoped<IEmployeeAccess, EmployeeAccess>();
builder.Services.AddScoped<IDepartmentAccess, DepartmentAccess>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
    policy.WithOrigins("http://localhost:7298", "https://localhost:7298")
          .AllowAnyMethod()
          .WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
