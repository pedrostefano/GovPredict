using System.Collections.Generic;

namespace GovPredict.Models
{
  public class List : BaseEntity
  {

    public string Name { get; set; }
    public ICollection<UserList> UserLists { get; set; }

  }
}
