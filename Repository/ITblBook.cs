using System.Collections.Generic;

namespace libraryManagement.Repository
{
    public interface ITblBook
    {
        libraryManagement.Models.TblBook GetBookById(int id);
        bool InsertBook(libraryManagement.Models.TblBook entity);
        bool UpdateBook(libraryManagement.Models.TblBook entity);
        bool DeleteBook(int id);
        IEnumerable<libraryManagement.Models.TblBook> GetBooks();

        IEnumerable<libraryManagement.Models.TblBook> GetBooksByName(string name);

    }
}