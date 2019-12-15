namespace GovPredict.VOs
{
  public class SummaryVO
  {
    public SummaryVO() { }

    public SummaryVO(int PageIndex, int ListSize, int ReturnedListSize)
    {
      this.ListSize = ListSize;
      this.ReturnedListSize = ReturnedListSize;
      this.PageIndex = PageIndex;
    }
    public int PageIndex { get; set; }
    public int ListSize { get; set; }
    public int ReturnedListSize { get; set; }
  }
}
