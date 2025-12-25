namespace ProductCatalog.WebAPI.DTOs;

/// <summary>
/// Pagination request parameters
/// </summary>
public record PaginationRequest
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
    
    public int Skip => (PageNumber - 1) * PageSize;
    public int Take => PageSize;
}

/// <summary>
/// Paginated response wrapper
/// </summary>
public record PagedResult<T>
{
    public IEnumerable<T> Items { get; init; } = Array.Empty<T>();
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public int TotalCount { get; init; }
    public int TotalPages { get; init; }
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
}
