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

app.MapGet("/users", () =>
    new List<User>
    {
        new()
        {
            Firstname = "John",
            Lastname = "Doe"
        },
        new()
        {
            Firstname = "James",
            Lastname = "Smith"
        }
    });

app.Run();

internal record User
{
    public string? Firstname { get; init; }
    
    public string? Lastname { get; init; }
}
