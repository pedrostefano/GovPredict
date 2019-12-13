using System.Collections.Generic;

namespace GovPredict.Models
{
  public class SocialNetwork : BaseEntity
  {

    public string Name { get; set; }
    public ICollection<Account> Accounts { get; set; }

  }
}
