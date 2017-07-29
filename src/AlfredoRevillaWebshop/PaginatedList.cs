using System;
using System.Collections.Generic;

namespace AlfredoRevillaWebshop
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(IEnumerable<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }

        public bool HasNextPage
        {
            get
            {
                return TotalPages > PageIndex + 1;
            }
        }

        public bool HasPreviousPage
        {
            get
            {
                return PageIndex > 0;
            }
        }

        public int PageIndex { get; }
        public int TotalPages { get; }
    }
}