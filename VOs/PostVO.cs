using System;

namespace GovPredict.VOs
{
  public class PostVO
  {
    public string Content { get; set; }
    public string Link { get; set; }
    public string User { get; set; }
    public string SocialNetwork { get; set; }
    public string[] PeopleList { get; set; }
    public DateTime Date { get; set; }

  }
}
