using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace libraryManagement.Models
{
    [Table("tbl_book")]
    public partial class TblBook
    {
        public TblBook()
        {
            TblBookAuthors = new HashSet<TblBookAuthor>();
            TblBookCopies = new HashSet<TblBookCopy>();
            TblBookLoans = new HashSet<TblBookLoan>();
        }

        public int BookBookId { get; set; }
        public string BookTitle { get; set; }
        public string BookPublisherName { get; set; }

        public virtual TblPublisher BookPublisherNameNavigation { get; set; }
        public virtual ICollection<TblBookAuthor> TblBookAuthors { get; set; }
        public virtual ICollection<TblBookCopy> TblBookCopies { get; set; }
        public virtual ICollection<TblBookLoan> TblBookLoans { get; set; }
    }
}
