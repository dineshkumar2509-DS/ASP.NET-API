using libraryManagement.Models.DTO;

namespace libraryManagement.Repository
{
    public interface IBookCopy
    {
        BookCopyDTO GetBookWithCopy(int Id);
        bool InsertBookWithCopy(BookCopyDTO bookCopy);
    }
}