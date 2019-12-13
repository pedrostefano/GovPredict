
namespace GovPredict.Models
{
  public class Post : BaseEntity
  {

    public string Content { get; set; }
    public string Link { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; }

  }
}
