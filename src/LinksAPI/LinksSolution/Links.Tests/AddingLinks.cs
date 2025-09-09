
using Alba;

namespace Links.Tests;
public class AddingLinks
{

    [Fact]
    public async Task AddingALinkReturnsA200()
    {
        // this is low rent, we have a better way to do this, come back tomorrow.
        //var client = new HttpClient();
        //client.BaseAddress = new Uri("http://localhost:1337");

        //var response = await client.PostAsJsonAsync("/links", new { });

        //Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        // this will start up (host) my API for me in this test.
        var host = await AlbaHost.For<Program>();
        // Given I post this data to this API, then this should happen.
       await host.Scenario(api =>
        {
            api.Post.Json(new { }).ToUrl("/links");
            api.StatusCodeShouldBeOk();
        });


    }
}
