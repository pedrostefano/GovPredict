using System;

namespace GovPredict.VOs
{
  public class PostFilter
  {
    public DateTime InitialDate { get; set; }
    public DateTime FinalDate { get; set; }
    public ESocialNetwork[] SocialNetwork { get; set; }
    public int[] PeopleList { get; set; }
    public string Content { get; set; }
  }
}
