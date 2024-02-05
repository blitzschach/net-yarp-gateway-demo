var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/books", () =>
    new List<Book>
    {
        new()
        {
            Author = "George Orwell",
            PageCount = 328,
            Title = "1984"
        },
        new()
        {
            Author = "F. Scott Fitzgerald",
            PageCount = 272,
            Title = "The Great Gatsby"
        },
        new()
        {
            Author = "Ernest Hemingway",
            PageCount = 128,
            Title = "The Old Man and the Sea"
        }
    });

app.Run();

internal record Book
{
    public string? Author { get; init; }
    
    public int PageCount { get; init; }
    
    public string? Title { get; init; }
}