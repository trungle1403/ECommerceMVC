using Microsoft.EntityFrameworkCore;

namespace ECommerceMVC.Models
{
    public class PaginatedList<T>
    {
        public List<T> List { get; set; }
        public int PageIndex { get; set; }  
        public int TotalPages { get; set; }
        public static int PageSize { get; set; } = 10;



        public PaginatedList(List<T> source,int count, int pageIndex) {
            PageIndex = pageIndex;
            List = source;
            TotalPages = (int) Math.Ceiling(count / (double) PageSize);
        }

        public static async Task<PaginatedList<T>> CreatePagination(IQueryable<T> soucre, int pageIndex)
        {
            var count = await soucre.CountAsync();
            var resultList = await soucre.Skip((pageIndex - 1) * PageSize).Take(PageSize).ToListAsync();
            return new PaginatedList<T>(resultList, count, pageIndex);
        }
    }
}
