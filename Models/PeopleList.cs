using System.Collections.ObjectModel;

namespace GovPredict.Models
{
  public class PeopleList : BaseEntity
  {

    public string Name { get; set; }
    public Collection<User> User { get; set; }

  }
}
