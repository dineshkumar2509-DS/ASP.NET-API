using System;
using System.Collections.Generic;

#nullable disable

namespace libraryManagement.Models
{
    public partial class TblLibraryBranch
    {
        public TblLibraryBranch()
        {
            TblBookCopies = new HashSet<TblBookCopy>();
            TblBookLoans = new HashSet<TblBookLoan>();
        }

        public int LibraryBranchBranchId { get; set; }
        public string LibraryBranchBranchName { get; set; }
        public string LibraryBranchBranchAddress { get; set; }

        public virtual ICollection<TblBookCopy> TblBookCopies { get; set; }
        public virtual ICollection<TblBookLoan> TblBookLoans { get; set; }
    }
}
