using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadersHub.Contracts.Books;
using ReadersHub.Core.Queries;
using ReadersHub.Data;
using ReadersHub.Data.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.
    AddDbContext<ReadersHubContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddGraphQLServer()
    .AddQueryType<BooksQuery>();

builder.Services.AddSingleton<BooksData>();
builder.Services.AddScoped<BooksQuery>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGraphQL();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/book", async (Book book, BooksQuery handler) =>
{
    await handler.AddBook(book);
    return Results.Created("/book", null);
});

app.MapDelete("/book/{id}", async (int id, BooksQuery handler) =>
{
    await handler.DeleteBook(id);
    return Results.Ok();
});

app.Run();