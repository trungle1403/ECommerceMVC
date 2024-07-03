using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Models
{
    public class PaginatedList<T>
    {
        public List<T> List { get; set; }
        public int PageIndex { get; set; }  
        public int TotalPages { get; set; }
        public static int PageSize { get; set; } = 5;



        public PaginatedList(List<T> source,int count, int pageIndex) {
            PageIndex = pageIndex;
            List = source;
            TotalPages = (int) Math.Ceiling(count / (double) PageSize);
        }

        public static async Task<PaginatedList<T>> CreatePagination(IEnumerable<T> soucre, int pageIndex)
        {
            var count = soucre.Count();
            var resultList = soucre.Skip((pageIndex - 1) * PageSize).Take(PageSize).ToList();
            return new PaginatedList<T>(resultList, count, pageIndex);
        }
    }
}
