using Microsoft.EntityFrameworkCore;
using PocEconimics.Helper;
using PocEconimics.Repository;
using PocEconimics.Services;
using PocEconomicsAPI.Models;
using PocEconomicsAPI.Repository;
using PocEconomicsAPI.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerRepositores, CustomerRepositores>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAPICustomerHandler, APICustomerHandler>();
builder.Services.AddScoped<IAPIRequestHandler, APIRequestHandler>();
builder.Services.AddScoped<IinvoiceService, InvoiceService>();
builder.Services.AddScoped<IOrderServices , OrderServices>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepositores>();
builder.Services.AddScoped<IFileQueueInboundRepositores, FileQueueInboundRepositores>();
//builder.Services.AddScoped < IinvoiceRegistrationService, RegistrationInvoiceService>();
builder.Services.AddScoped<IEntryService, EntrysService>();
builder.Services.AddScoped<ICSVFormatService,CSVFormatService>();





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
