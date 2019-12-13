using System;

namespace GovPredict.VOs
{
  public class PostVO
  {
    public string Content { get; set; }
    public string Link { get; set; }
    public string User { get; set; }
    public string Account { get; set; }
    public string SocialNetwork { get; set; }
    public string[] Lists { get; set; }
    public DateTime Date { get; set; }
    public SummaryVO Summary { get; set; }

  }
}
