namespace RentHouse.Application.Common.Pagination
{
	public class PaginatedResult<T>
	{
		public IEnumerable<T> Items { get; set; }
		public int TotalCount { get; set; }
		public int PageNumber { get; set; }
		public int PageSize { get; set; }

		public bool NextPageAvailable => (PageNumber * PageSize) < TotalCount;
		public bool PreviousPageAvailable => PageNumber > 1;
		public PaginatedResult(IEnumerable<T> items, int totalCount, int pageNumber, int pageSize)
		{
			Items = items;
			TotalCount = totalCount;
			PageNumber = pageNumber;
			PageSize = pageSize;
		}
	}
}
