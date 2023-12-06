using FluentValidation.AspNetCore;
using MyScrutor.Models;
using MyScrutor.Services.Generic;
using MyScrutor.Services.Simple;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Simple Decoration
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.Decorate<IBookRepository, BookRepositoryValidator>();
#endregion

#region Genereic Decoration
builder.Services.Scan(scan=>scan.FromAssembliesOf(typeof(IRepository<>))
.AddClasses(classes=>classes.AssignableTo(typeof(IRepository<>)).Where(_=>!_.IsGenericType))
.AsImplementedInterfaces()
.WithTransientLifetime()
);
builder.Services.Decorate(typeof(IRepository<>), typeof(GenericRipositoryValidator<>));


//builder.Services.AddTransient<IRepository<Book>, GenericBookRepository>();
//builder.Services.Decorate<IRepository<Book>, GenericRipositoryValidator<Book>>();

#endregion

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
