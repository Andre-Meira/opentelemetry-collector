using AspireApp.ServiceDefaults.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


builder.AddServiceDefaults();

builder.Services.AddProblemDetails();
var app = builder.Build();
app.UseExceptionHandler();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/click/{button}/{username}", 
(
    [FromServices] ILogger<Program> logger,
    [FromServices] IClickMetrics metrics,
    string button, string username
) =>
{
    var click = new Click(username, button);
    
    metrics.UserClicked(click);
    logger.ClickButton(click);

    return "ButtonClicked";
});

app.MapGet("/click",
(
    [FromServices] ILogger<Program> logger
) =>
{
    //logger.LogInformation("{message}", "testeeee");
    logger.Button(new Teste());

    return "ButtonClicked";
});


app.MapDefaultEndpoints();

app.Run();


public static partial class TesteLoggerExtensions
{
    [LoggerMessage(
        EventId = 1,
        EventName = "",
        Level = LogLevel.Information,
        Message = "Button")]
    public static partial void Button(this Microsoft.Extensions.Logging.ILogger logger, [LogProperties] Teste click);
}


public class Teste
{
    public Guid Guid { get; set; }
    public string Name { get; set; } = "Test";

    public Teste1[] Array { get; set; }

    public Teste()
    {
        Guid = Guid.NewGuid();
        Array = new Teste1[]
        {
            new Teste1("aaaaaa", 1),
            new Teste1("aaaaaa", 2),
            new Teste1("aaaaaa", 3),
        };
    }
}

public class Teste1
{
    public Teste1(string name, int idade)
    {
        Name = name;
        Idade = idade;
    }

    public string Name { get; set; }
    public int Idade { get; set; }
}