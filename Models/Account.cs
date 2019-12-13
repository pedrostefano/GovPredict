using System.Collections.Generic;

namespace GovPredict.Models
{
  public class Account : BaseEntity
  {

    public string Name { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int SocialNetworkId { get; set; }
    public SocialNetwork SocialNetwork { get; set; }
    public ICollection<Post> Posts { get; set; }
  }
}
