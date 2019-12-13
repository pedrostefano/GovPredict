using System.Collections.Generic;
using System.Linq;
using GovPredict.Models;
using GovPredict.VOs;
using Microsoft.EntityFrameworkCore;

public class PostService
{

  public IEnumerable<PostVO> GetAllPostsFromFilter(PostFilter filter)
  {
    using (var db = new GovPredictContext())
    {
      var posts = db.Posts
        .Where(p =>
          p.Content.Contains(filter.Content)
          || (p.CreatedAt >= filter.InitialDate && p.CreatedAt <= filter.FinalDate)
          || filter.SocialNetworks.Contains(p.Account.SocialNetwork)
          || p.Account.User.UserLists.Select(ul => ul.List).Any(ul => filter.Lists.ToList().Contains(ul.Name))
        )
        .Select(p => new PostVO()
        {
          User = p.Account.User.Name,
          Account = p.Account.Name,
          Date = p.CreatedAt,
          Content = p.Content,
          Link = p.Link,
          Lists = p.Account.User.UserLists.Select(ul => ul.List.Name).ToArray(),
          SocialNetwork = p.Account.SocialNetwork.ToString()
        }

      );

      return posts;

    }
  }

}