using LibraryManagementApp.Contexts;
using LibraryManagementApp.Interfaces;
using LibraryManagementApp.Models;
using LibraryManagementApp.Repositories;
using LibraryManagementApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region  DbConfig
builder.Services.AddDbContext<LibraryDbContext>(options=>
        options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
#endregion


#region  repository
builder.Services.AddScoped<IBookRepository<int,string,Book>,BookRepository>();
builder.Services.AddScoped<IMemberRepository<int,string,Member>,MemberRepository>();
#endregion

#region  Service
builder.Services.AddScoped<IBookService,BookService>();
builder.Services.AddScoped<IMemberService,MemberService>();

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
