using System.Collections.ObjectModel;

namespace GovPredict.Models
{
  public class User : BaseEntity
  {

    public string Name { get; set; }
    public Collection<Profile> Profiles { get; set; }

  }
}
