namespace ContactsApi;

public class PageResult<TResult>
    where TResult: class
{
    public int Count { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public List<TResult> Items { get; set; }

    public PageResult(int page, int pageSize, int count)
    {
        PageIndex = page <= 0 ? 1 : page;
        PageSize = pageSize <= 0 ? 1 : pageSize;
        Count = count;
    }
}