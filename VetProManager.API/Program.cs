using FluentValidation;
using Microsoft.EntityFrameworkCore;
using VetProManager.DAL.Context;
using VetProManager.DAL.Contracts.BaseContracts;
using VetProManager.DAL.Contracts.Modules.CRM;
using VetProManager.DAL.Modules.Shared;
using VetProManager.DAL.Repositories;
using VetProManager.DAL.Repositories.Modules.CRM;
using VetProManager.DAL.Repositories.Modules.Shared;
using VetProManager.DAL.UnitOfWorks;
using VetProManager.Service.Contract.Modules.CRM;
using VetProManager.Service.Contract.Modules.Shared;
using VetProManager.Service.DTOs;
using VetProManager.Service.Modules.CRM;
using VetProManager.Service.Modules.Shared;
using VetProManager.Service.Validations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VetProManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<IRepository<Species>, SpeciesRepository>();
builder.Services.AddScoped<SpeciesService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

//FluentValidation
builder.Services.AddScoped<SpeciesValidator>();

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
