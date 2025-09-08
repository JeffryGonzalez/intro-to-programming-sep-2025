

using Microsoft.AspNetCore.Mvc;

namespace Links.Api.Links;


// When a POST comes in for "/links", create a instance of this class, oh Kestral Web Server

public class LinksController : ControllerBase
{
    // "Flag - a "Marker" on this method, that the API will read and know this is where
    // POSTs to "/links" should be directed.
    [HttpPost("/links")]
    public async Task<ActionResult> AddALink()
    {
        return Ok();
    }
}
