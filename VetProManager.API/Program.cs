using FluentValidation;
using VetProManager.Service.Contract.Modules;
using VetProManager.Service.DTOs;
using VetProManager.Service.Modules.CRM;
using VetProManager.Service.Validations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
