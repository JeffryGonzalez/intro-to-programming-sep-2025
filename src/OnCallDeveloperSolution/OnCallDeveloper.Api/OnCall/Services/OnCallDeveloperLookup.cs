using OnCallDeveloper.Api.OnCall.Models;

namespace OnCallDeveloper.Api.OnCall.Services;


public class OnCallDeveloperLookUp
{
    public async Task<OnCallDeveloperResponse> GetOnCallDeveloper()
    {
        if (DateTime.Now.Hour >= 9 && DateTime.Now.Hour < 17)
        {
            return new OnCallDeveloperResponse("Charlie", "charlie@aol.com");
        }
        else
        {
            return new OnCallDeveloperResponse("Jake", "jake@offsitesupport.com");
        }
    }
}