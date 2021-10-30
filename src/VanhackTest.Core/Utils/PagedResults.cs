using System.Collections.Generic;

namespace VanhackTest.Core.Utils
{
  public class PagedResults<T>
    {
        public PagedResults()
        {

        }

        public PagedResults(IEnumerable<T> items, int totalCount) : this()
        {
            this.Items = items;
            this.TotalCount = totalCount;
        }

        public PagedResults(IEnumerable<T> items, int totalCount, int pageSize, int pageSkip) : this(items, totalCount)
        {
            this.PageSize = pageSize;
            this.PageSkip = pageSkip;
        }
        

        public IEnumerable<T> Items { get; set; } = new List<T>();

        public int PageSize { get; set; } = 10;
        public int PageSkip { get; set; } = 0;

        public int TotalCount { get; set; } = 0;
        public int TotalPages
        {
            get
            {
                return TotalCount <= PageSize ? 1 : (int)System.Math.Ceiling((decimal)TotalCount / PageSize);
            }
        }
        public int PageNumber
        {
            get
            {
                return PageSkip < PageSize ? 1 : (int)System.Math.Ceiling((decimal) ( PageSize + PageSkip) / PageSize);
            }
        }
        public bool HasPrevious => PageNumber > TotalPages;
        public bool HasNext => PageNumber < TotalPages;
    }
}