using System;
using System.Collections.Generic;

#nullable disable

namespace libraryManagement.Models
{
    public partial class TblBookAuthor
    {
        public int BookAuthorsAuthorId { get; set; }
        public int BookAuthorsBookId { get; set; }
        public string BookAuthorsAuthorName { get; set; }

        public virtual TblBook BookAuthorsBook { get; set; }
    }
}
