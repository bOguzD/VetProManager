using FluentValidation;
using Microsoft.EntityFrameworkCore;
using VetProManager.DAL.Context;
using VetProManager.DAL.UnitOfWorks;
using VetProManager.Service.Contract.Modules.CRM;
using VetProManager.Service.DTOs;
using VetProManager.Service.Modules.CRM;
using VetProManager.Service.Validations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VetProManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

//FluentValidation
builder.Services.AddScoped<IValidator<SpeciesDTO>, SpeciesValidator>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
