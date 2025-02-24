using System.Collections.Generic;

namespace GovPredict.Models
{
  public class User : BaseEntity
  {

    public string Name { get; set; }
    public ICollection<UserList> UserLists { get; set; }
    public ICollection<Account> Accounts { get; set; }

  }
}
