using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlfredoRevillaWebshop.Models
{
    public class PagedResult<TElement> : IEnumerable<TElement>
    {
        private TElement[] _collection;

        internal PagedResult(TElement[] collection, int totalElements)
        {
            this._collection = collection;
            this.TotalElements = totalElements;
        }

        public int TotalElements { get; }

        public IEnumerator<TElement> GetEnumerator()
        {
            return ((IEnumerable<TElement>)_collection).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _collection.GetEnumerator();
        }
    }
}