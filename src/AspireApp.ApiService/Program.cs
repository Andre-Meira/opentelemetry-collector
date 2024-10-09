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
    [FromServices] ILogger logger,
    [FromServices] IClickMetrics metrics,
    string button, string username
) =>
{
    var click = new Click(username, button);
    
    metrics.UserClicked(click);
    logger.ClickButton(click);

    return "ButtonClicked";
});

app.MapDefaultEndpoints();

app.Run();

