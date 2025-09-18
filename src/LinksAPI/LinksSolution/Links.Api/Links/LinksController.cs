

using System.ComponentModel.DataAnnotations;
using Marten;
using Microsoft.AspNetCore.Mvc;
using Weasel.Postgresql.Tables;

namespace Links.Api.Links;


// When a POST comes in for "/links", create a instance of this class, oh Kestral Web Server

[ApiController]
public class LinksController(IDocumentSession session, IManagerUserIdentity userIdentityManager) : ControllerBase
{
    // GET /links
    // GET /link?sortOrder=NewestFirst
    [HttpGet("/links")]
    public async Task<ActionResult<IReadOnlyList<CreateLinkResponse>>> GetAllLinksAsync([FromQuery] string sortOrder = "OldestFirst")
    {
        var response = session.Query<CreateLinkResponse>();

        if(sortOrder == "NewestFirst")
        {
            response = (Marten.Linq.IMartenQueryable<CreateLinkResponse>)response.OrderByDescending(link => link.Created);
        }

        var results = await response.ToListAsync();
        //await Task.Delay(3000);
        return Ok(results);
    }

    [HttpPost("/links")]
    public async Task<ActionResult<CreateLinkResponse>> AddALink(
        [FromBody] CreateLinkRequest request
        )
    {
        string userSubject = await userIdentityManager.GetSubjectAsync();

        var response = new CreateLinkResponse {
            Id = Guid.NewGuid(),
            Href = request.Href,
            Description = request.Description,
            AddedBy = userSubject,
            Created = DateTimeOffset.Now,
            Title = request.Title,
        };
        session.Store(response);
        await session.SaveChangesAsync();
    
        return Created($"/links/{response.Id}", response);
    }

    // If we get a GET request to /links/{guid} THEN create this controller and run this method, if isn't, don't bother me, just return 404
    [HttpGet("/links/{postId:guid}")]
    public async Task<ActionResult<CreateLinkResponse>> GetLinkById(Guid postId)
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
    [Required] // "Declarative Programming"
    public string Href { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required, MaxLength(100)]
    public string Title { get; set;} = string.Empty;

}



public record CreateLinkResponse
{
    // uuid 
    public Guid Id { get; set; }
    public string Href { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string AddedBy { get; set; } = string.Empty;
    public DateTimeOffset Created { get; set; }
    public string Title { get; set; } = string.Empty;
}
