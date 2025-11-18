using System;

namespace Bps.Bomex.Models
{
    public class RecursiveEventArgs : EventArgs
    {
        public SearchResult SearchResults { get; }

        public RecursiveEventArgs(SearchResult searchResults)
        {
            SearchResults = searchResults;
        }
    }
}
