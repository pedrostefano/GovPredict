using System.Collections.Generic;
using GovPredict.VOs;
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

    [HttpPost("filter")]
    public IEnumerable<PostVO> GetWithFilter([FromBody]PostFilter filter)
    {
      var posts = PostService.GetAllPostsFromFilter(filter);
      return posts;
    }
  }
}
