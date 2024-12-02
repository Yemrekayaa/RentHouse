namespace RentHouse.Dto
{
    public abstract class PaginationDtoBase
    {
        public int totalCount { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public bool nextPageAvailable { get; set; }
        public bool previousPageAvailable { get; set; }
    }

    public class PaginationDto<T> : PaginationDtoBase
    {
        public IEnumerable<T> Items { get; set; }
    }
}
