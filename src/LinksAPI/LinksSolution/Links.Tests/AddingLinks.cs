
using Alba;
using Links.Api.Links;
using Marten;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

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
        var host = await AlbaHost.For<Program>(config =>
        {
            //config.ConfigureTestServices(sp =>
            //{
            //    var fakeDocumentSession = Substitute.For<IDocumentSession>();
            //    fakeDocumentSession.SaveChangesAsync().Throws(new OutOfMemoryException());
            //    sp.AddScoped<IDocumentSession>(_ => fakeDocumentSession);
            //});
        });
        // Given I post this data to this API, then this should happen.
        // "Desliming"
        var linkToAdd = new CreateLinkRequest
        {
            Href = "https://microsoft.com",
            Description = "Where do you want to go today?"
        };
       var postResponse = await host.Scenario(api =>
        {
            api.Post.Json(linkToAdd).ToUrl("/links");
            api.StatusCodeShouldBe(201); // Created.
        });

        var postBody = postResponse.ReadAsJson<CreateLinkResponse>();

        Assert.NotNull(postBody);
        Assert.Equal(linkToAdd.Description, postBody.Description);
        Assert.Equal(linkToAdd.Href, postBody.Href);
        Assert.Equal("joe@aol.com", postBody.AddedBy); // Slime!
        //Assert.Equal(DateTimeOffset.Now, postBody.Created, TimeSpan.FromMilliseconds(500)); // Minor Slime!
        Assert.NotEqual(Guid.Empty, postBody.Id); // Super slimy 

        var locationHeader = postResponse.Context.Response.Headers.Location.ToString();
        Assert.NotNull(locationHeader);
        var getResponse = await host.Scenario(api =>
        {
            api.Get.Url(locationHeader);
            api.StatusCodeShouldBeOk();
        });

        var getBody = getResponse.ReadAsJson<CreateLinkResponse>();
        Assert.NotNull(getBody);

        Assert.Equal(postBody, getBody);
    }
}
