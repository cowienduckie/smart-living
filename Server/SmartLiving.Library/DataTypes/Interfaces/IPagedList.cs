using System.Collections.Generic;

namespace SmartLiving.Library.DataTypes.Interfaces
{
    public interface IPagedList<T> : IList<T>
    {
        int PageIndex { get; }
        int PageSize { get; }
        int TotalCount { get; }
        int TotalPage { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}