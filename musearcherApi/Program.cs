using Microsoft.AspNetCore.Mvc;
using musearcherApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    return $"/";
});

app.MapGet("/song", ([FromQuery] string lirycs) =>
{
    Console.WriteLine(lirycs);
    Welcome json = convert.getValueFromGeniusJson((httpClient.Get($"https://api.genius.com/search?q={lirycs}").Result).ToString());
    return Model.Response.CreateJsonResponse(json);
});

app.Run($"https://127.0.0.1:{port}");