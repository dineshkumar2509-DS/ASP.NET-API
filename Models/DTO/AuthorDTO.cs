using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace libraryManagement.Models.DTO
{
    public class AuthorDTO
    {
        public int BookAuthorsBookId { get; set; }
        public string BookAuthorsAuthorName { get; set; }
    }
}