using GovPredict.VOs;

namespace GovPredict.Models
{
  public class Profile : BaseEntity
  {

    public string Name { get; set; }
    public User User { get; set; }
    public ESocialNetwork SocialNetwork { get; set; }

  }
}
