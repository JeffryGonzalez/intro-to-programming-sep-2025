
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
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

app.MapControllers();

app.Run(); // This is where our API will be up and running, listening for requests.
// This is basically a while(true) {...} loop that will run "forever"


