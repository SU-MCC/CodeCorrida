using CodeCorrida.Application.DTOs.Common;
using Mapster;

namespace CodeCorrida.Web.Models.Responses.Common;

public class PagedListResponse<T>
{
    public int CurrentPage { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }
    public int TotalPages { get; private set; }
    public IEnumerable<T> Items { get; private set; }

    public PagedListResponse(IEnumerable<T> items, int count, int currentPage, int pageSize)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalCount = count;
        TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
        Items = items;
    }

    public static PagedListResponse<T> ToPagedListResponse<Y>(PagedListDto<Y> original) 
    {
        var result = original.Adapt<IEnumerable<T>>();
        return new PagedListResponse<T>(result, original.TotalCount, original.CurrentPage, original.PageSize);
    }
}
