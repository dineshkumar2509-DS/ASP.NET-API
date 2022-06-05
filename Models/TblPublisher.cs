using System;
using System.Collections.Generic;

#nullable disable

namespace libraryManagement.Models
{
    public partial class TblPublisher
    {
        public TblPublisher()
        {
            TblBooks = new HashSet<TblBook>();
        }

        public string PublisherPublisherName { get; set; }
        public string PublisherPublisherAddress { get; set; }
        public string PublisherPublisherPhone { get; set; }

        public virtual ICollection<TblBook> TblBooks { get; set; }
    }
}
