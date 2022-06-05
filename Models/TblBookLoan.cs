using System;
using System.Collections.Generic;

#nullable disable

namespace libraryManagement.Models
{
    public partial class TblBookLoan
    {
        public int BookLoansLoansId { get; set; }
        public int BookLoansBookId { get; set; }
        public int BookLoansBranchId { get; set; }
        public int BookLoansCardNo { get; set; }
        public string BookLoansDateOut { get; set; }
        public string BookLoansDueDate { get; set; }

        public virtual TblBook BookLoansBook { get; set; }
        public virtual TblLibraryBranch BookLoansBranch { get; set; }
        public virtual TblBorrower BookLoansCardNoNavigation { get; set; }
    }
}
