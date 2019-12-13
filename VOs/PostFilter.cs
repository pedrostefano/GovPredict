using System;

namespace GovPredict.VOs
{
  public class PostFilter
  {
    public DateTime InitialDate { get; set; }
    public DateTime FinalDate { get; set; }
    public ESocialNetwork[] SocialNetworks { get; set; }
    public string[] Lists { get; set; }
    public string Content { get; set; }
    public string Account { get; set; }
  }
}
