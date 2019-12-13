using System.Collections.Generic;
using System.Linq;
using GovPredict.Models;
using GovPredict.VOs;

public class PostService
{

  public static IEnumerable<PostVO> GetAllPostsFromFilter(PostFilter filter)
  {
    using (var db = new GovPredictContext())
    {
      var posts = db.Posts
        .Where(p =>
          (filter.Content == null || p.Content.Contains(filter.Content))
          && (filter.InitialDate == null || (p.Date >= filter.InitialDate))
          && (filter.FinalDate == null || (p.Date <= filter.FinalDate))
          && (filter.SocialNetworks == null || filter.SocialNetworks.ToList().Contains(p.Account.SocialNetwork.Name))
          && (filter.Lists == null || p.Account.User.UserLists.Select(ul => ul.List).Any(ul => filter.Lists.ToList().Contains(ul.Name)))
        )
        .Select(p => new PostVO()
        {
          User = p.Account.User.Name,
          Account = p.Account.Name,
          Date = p.Date,
          Content = p.Content,
          Link = p.Link,
          Lists = p.Account.User.UserLists.Select(ul => ul.List.Name).ToArray(),
          SocialNetwork = p.Account.SocialNetwork.Name
        }
      ).ToList();

      return posts;

    }
  }

}