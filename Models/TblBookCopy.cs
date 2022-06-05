using System;
using System.Collections.Generic;

#nullable disable

namespace libraryManagement.Models
{
    public partial class TblBookCopy
    {
        public int BookCopiesCopiesId { get; set; }
        public int BookCopiesBookId { get; set; }
        public int BookCopiesBranchId { get; set; }
        public int BookCopiesNoOfCopies { get; set; }

        public virtual TblBook BookCopiesBook { get; set; }
        public virtual TblLibraryBranch BookCopiesBranch { get; set; }
    }
}
