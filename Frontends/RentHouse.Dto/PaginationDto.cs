namespace RentHouse.Dto
{
    public class PaginationDto<T>
    {
        public IEnumerable<T> items { get; set; }
        public int totalCount { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public bool nextPageAvailable { get; set; }
        public bool previousPageAvailable { get; set; }
    }
}
