// This is compiling to an INTERNAL class called Program without a Namespace, and it has a method called "Main"
using Links.Api.Links;
using Marten;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// This is CLASSROOM CODE
// do not copy and paste this into production code - check with your local experts on what they want.

builder.Services.AddCors(c =>
{
    c.AddDefaultPolicy(pol =>
    {
      
        pol.AllowAnyOrigin();
        pol.AllowAnyMethod();
        pol.AllowAnyHeader();
        // "promiscuous mode"
    });
});
var connectionString = builder.Configuration.GetConnectionString("links") 
    ?? throw new Exception("You Need a Connection String!");


// Singleton in this use means create one of these the first time anyone needs it
// and then reuse the same instance for all of eternity (until the app shuts down)
// Scoped means this will be create new for each request, and reused, if needed, during that request.
builder.Services.AddScoped<IManagerUserIdentity, JwtUserIdentityManager>();
builder.Services.AddMarten(config =>
{

    config.Connection(connectionString);
}).UseLightweightSessions();

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
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");

    });
}

app.UseAuthorization();

app.MapControllers(); // Create a "phone book" of possible things this API can expect.
// For example, when someone does a POST to "/links", create the LinksController and call the AddLink method.
// Route Table.
app.UseCors();
app.Run(); // This is where our API will be up and running, listening for requests.
// This is basically a while(true) {...} loop that will run "forever"


// I want to make this "Program" class visible to to my tests. 
// But you are not allowed to ask me any questions about this YET.
public partial class Program;
