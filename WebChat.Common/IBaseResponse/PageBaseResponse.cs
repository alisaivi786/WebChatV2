namespace WebChat.Common.IBaseResponse;

public class IPageBase
{
    public int? PageNo { get; set; } = 1;
    public int? TotalPage { get; set; } = 20;
    public int? TotalCount { get; set; } = 0;

}
public class PageBaseResponse<T> : IPageBase
{
    public T? List { get; set; }
}
public class PageBaseDataResponse<T> : IPageBase
{
    public T? Data { get; set; }

}
public class PageBaseObjResponse : IPageBase
{
    public object? Data { get; set; }

}
public class PageBaseObjResponse<TList, TObj> : PageBaseResponse<TList>
{
    public TObj? Data { get; set; }
}
