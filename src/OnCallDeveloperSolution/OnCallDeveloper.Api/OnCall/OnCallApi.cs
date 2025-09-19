using Microsoft.AspNetCore.Mvc;
using OnCallDeveloper.Api.OnCall.Services;

namespace OnCallDeveloper.Api.OnCall;

public static class OnCallApi
{

    public static IServiceCollection AddOnCallDeveloperServices(this IServiceCollection services)
    {
        services.AddScoped<OnCallDeveloperLookUp>();
        return services;
    }
    public static WebApplication MapOnCallApi(this WebApplication app)
    {

        app.MapGet("/oncalldeveloper", async (

            [FromServices] OnCallDeveloperLookUp lookup) =>
        {
            return await lookup.GetOnCallDeveloper();
        });


        return app;
    }
}
