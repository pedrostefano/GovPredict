using System;
using GovPredict.VOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GovPredict.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PostController : ControllerBase
  {
    private readonly ILogger<PostController> _logger;

    public PostController(ILogger<PostController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public PostVO Get()
    {
      return new PostVO();
    }

    [HttpPost("filter/{PageIndex}/{ListSize}")]
    public ActionResult GetWithFilter([FromBody]PostFilter filter, int PageIndex, int ListSize)
    {
      try
      {
        var response = PostService.GetAllPostsFromFilter(filter, PageIndex, ListSize);
        return Ok(response);
      }
      catch (Exception)
      {
        return StatusCode(StatusCodes.Status500InternalServerError);
      }
    }
  }
}
