using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace libraryManagement.Models.DTO
{
    public class BookCopyDTO
    {
        public int? BookBookId { get; set; }
        public string BookTitle { get; set; }
        public string BookPublisherName { get; set; }
        public int BookCopiesBranchId { get; set; }
        public int BookCopiesNoOfCopies { get; set; }

        public ICollection<AuthorDTO> Authors { get; set; }
    }
}