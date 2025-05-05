using Modsen.CodeCorrida.Web.Domain.RequestFeatures;
using Mapster;

namespace Modsen.CodeCorrida.Web.Application.DTOs.Common;

public class PagedListDto<T> : List<T>
{
    public int CurrentPage { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }
    public int TotalPages { get; private set; }

    public PagedListDto(IEnumerable<T> items, int count, int pageIndex, int pageSize)
    {
        CurrentPage = pageIndex;
        PageSize = pageSize;
        TotalCount = count;
        TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

        AddRange(items);
    }
    
    
    public static PagedListDto<T> ToPagedListDto<Y>(PagedList<Y> original)
    {
        var result = original.Adapt<IEnumerable<T>>();
        return new PagedListDto<T>(result, original.MetaData.TotalCount, original.MetaData.CurrentPage, original.MetaData.PageSize);
    }
}

