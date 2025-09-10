

using Marten;
using Microsoft.AspNetCore.Mvc;

namespace Links.Api.Links;


// When a POST comes in for "/links", create a instance of this class, oh Kestral Web Server

public class LinksController(IDocumentSession session) : ControllerBase
{
    // "Flag - a "Marker" on this method, that the API will read and know this is where
    // POSTs to "/links" should be directed.

    //private IDocumentSession session;

    //public LinksController(IDocumentSession session)
    //{
    //    this.session = session;
    //}

    [HttpPost("/links")]
    public async Task<ActionResult> AddALink(
        [FromBody] CreateLinkRequest request
        )
    {
        var response = new CreateLinkResponse
        {
            Id = Guid.NewGuid(),
            Href = request.Href,
            Description = request.Description,
            AddedBy = "joe@aol.com",
            Created = DateTimeOffset.Now
        };
        session.Store(response);
        await session.SaveChangesAsync(); 
        return Created($"/links/{response.Id}", response);
    }

    // If we get a GET request to /links/{guid} THEN create this controller and run this method, if isn't, don't bother me, just return 404
    [HttpGet("/links/{postId:guid}")]
    public async Task<ActionResult> GetLinkById(Guid postId)
    {
       var savedLink = await session.Query<CreateLinkResponse>().
            SingleOrDefaultAsync(x => x.Id == postId);

        //var totalNumberOflinksInTheLastWeek = await session.Query<CreateLinkResponse>()
        //    .Where(l => l.Created < DateTimeOffset.Now.AddDays(-7))
        //    .CountAsync();

        if(savedLink is null)
        {
            return NotFound();
        } else
        {
            return Ok(savedLink);
        }
    }
}

/*{
  "href": "https://typescriptlang.org",
  "description": "The TypeScript Website"
}*/
// "DTO" - "Data Transfer Object"

public record CreateLinkRequest
{
    public string Href { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}

/*{
  "id": "38983989839839839893",
  "href": "https://typescriptlang.org",
  "description": "The TypeScript Website",
  "addedBy": "jeff@hypertheory.com",
  "created": "some datetime"
}*/


public record CreateLinkResponse
{
    // uuid 
    public Guid Id { get; set; }
    public string Href { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string AddedBy { get; set; } = string.Empty;
    public DateTimeOffset Created { get; set; }
}
