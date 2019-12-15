using System.Linq;
using GovPredict.Models;
using GovPredict.VOs;

public class PostService
{

  public static ResponseVO GetAllPostsFromFilter(PostFilter filter, int PageIndex, int ListSize)
  {
    PageIndex = PageIndex == 0 ? 1 : PageIndex;
    ListSize = ListSize == 0 ? int.MaxValue : ListSize;

    using (var db = new GovPredictContext())
    {
      //Filtering
      var posts = db.Posts
        .Where(p =>
          (filter.Content == null || p.Content.Contains(filter.Content))
          && (filter.InitialDate == null || (p.Date >= filter.InitialDate))
          && (filter.FinalDate == null || (p.Date <= filter.FinalDate))
          && ((filter.SocialNetworks == null || filter.SocialNetworks.ToList().Count == 0) || filter.SocialNetworks.ToList().Contains(p.Account.SocialNetwork.Name))
          && ((filter.Lists == null || filter.Lists.ToList().Count == 0) || p.Account.User.UserLists.Select(ul => ul.List).Any(ul => filter.Lists.ToList().Contains(ul.Name)))
        );

      //Pagination
      var total = posts.Count();
      var result = posts
        .Skip((PageIndex - 1) * ListSize)
        .Take(ListSize)
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

      //Pagination
      var summary = new SummaryVO(PageIndex, ListSize, total);

      return new ResponseVO
      {
        Posts = result,
        Summary = summary
      };

    }
  }

}