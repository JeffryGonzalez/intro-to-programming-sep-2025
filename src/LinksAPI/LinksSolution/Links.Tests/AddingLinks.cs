
using System.Net.Http.Json;

namespace Links.Tests;
public class AddingLinks
{

    [Fact]
    public async Task AddingALinkReturnsA200()
    {
        // this is low rent, we have a better way to do this, come back tomorrow.
        var client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:1337");

        var response = await client.PostAsJsonAsync("/links", new { });

        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }
}
