using Microsoft.AspNetCore.Mvc;
using OnCallDeveloper.Api.OnCall;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOnCallDeveloperServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapOnCallApi();
app.Run();

