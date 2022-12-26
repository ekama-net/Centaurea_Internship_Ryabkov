using System.Collections.Generic;

namespace ConcertTickets
{
    public class IndexViewModel
    {
        public IEnumerable<Concert> Concerts { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public string SearchString { get; set; }    
    }
}
