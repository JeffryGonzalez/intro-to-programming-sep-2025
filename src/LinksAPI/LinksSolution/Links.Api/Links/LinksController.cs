

using Microsoft.AspNetCore.Mvc;

namespace Links.Api.Links;


// When a POST comes in for "/links", create a instance of this class, oh Kestral Web Server

public class LinksController : ControllerBase
{
    // "Flag - a "Marker" on this method, that the API will read and know this is where
    // POSTs to "/links" should be directed.
    [HttpPost("/links")]
    public async Task<ActionResult> AddALink(
        [FromBody] CreateLinkRequest request)
    {
        var response = new CreateLinkResponse
        {
            Id = Guid.NewGuid(),
            Href = request.Href,
            Description = request.Description,
            AddedBy = "joe@aol.com",
            Created = DateTimeOffset.Now
        };
        return Ok(response);
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
