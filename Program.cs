using AutoMapper;
using EmailSender.Services;
using EmailSender.Services.Data;
using EmailSender.Services.Mail_Service;
using EmailSender.Services.Mapping;
using EmailSender.Services.Repository;
using EmailSender.WebApi.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(x=>x.UseSqlite(builder.Configuration.GetConnectionString("DbConnect")));
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IMailRepository,MailRepository>();
builder.Services.AddTransient<IMailService, MailService>();
builder.Services.AddAutoMapper(typeof(MailMappingConfiguration));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<SMTPSettings>(builder.Configuration.GetSection("SMTPSettings"));
// configure strongly typed settings object
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



