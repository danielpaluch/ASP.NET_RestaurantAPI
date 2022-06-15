namespace RestaurantAPI2.Models
{
    public class RestaurantQuery
    {
        public string? SearchPhrase { get; set; } = null;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
