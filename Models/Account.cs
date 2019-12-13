using System.Collections.Generic;
using GovPredict.VOs;

namespace GovPredict.Models
{
  public class Account : BaseEntity
  {

    public string Name { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public ESocialNetwork SocialNetwork { get; set; }
    public ICollection<Post> Posts { get; set; }
  }
}
