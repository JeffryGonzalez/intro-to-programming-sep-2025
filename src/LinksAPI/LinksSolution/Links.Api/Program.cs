
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// everything above this line is "configuration" of the SERVICES that our API needs to run.
var app = builder.Build();
// Everything after this line, up to "app.Run()" is "Middleware" - telling our API how it should
// handle actual HTTP Requests and Responses.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers(); // Create a "phone book" of possible things this API can expect.
// For example, when someone does a POST to "/links", create the LinksController and call the AddLink method.
// Route Table.

app.Run(); // This is where our API will be up and running, listening for requests.
// This is basically a while(true) {...} loop that will run "forever"


