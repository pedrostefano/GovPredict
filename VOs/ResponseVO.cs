using System.Collections.Generic;

namespace GovPredict.VOs
{
  public class ResponseVO
  {
    public ICollection<PostVO> Posts { get; set; }
    public SummaryVO Summary { get; set; }
  }
}
