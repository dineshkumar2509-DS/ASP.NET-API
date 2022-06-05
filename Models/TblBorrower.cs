using System;
using System.Collections.Generic;

#nullable disable

namespace libraryManagement.Models
{
    public partial class TblBorrower
    {
        public TblBorrower()
        {
            TblBookLoans = new HashSet<TblBookLoan>();
        }

        public int BorrowerCardNo { get; set; }
        public string BorrowerBorrowerName { get; set; }
        public string BorrowerBorrowerAddress { get; set; }
        public string BorrowerBorrowerPhone { get; set; }

        public virtual ICollection<TblBookLoan> TblBookLoans { get; set; }
    }
}
