using AutoMapper;

namespace libraryManagement.Models.DTO.Mapper
{
    public class AllMappersProfile:Profile
    {
        public AllMappersProfile()
        {
            CreateMap<TblBook,BooksDTO>();//mapping between books to booksDTO    source/destination
            CreateMap<BooksDTO,TblBook>();//mapping from booksDTO and books

            CreateMap<TblBookCopy,BookCopyDTO>();
            CreateMap<TblBook,BookCopyDTO>();

            CreateMap<BookCopyDTO,TblBookCopy>();
            CreateMap<BookCopyDTO,TblBook>();

            CreateMap<TblBookAuthor,AuthorDTO>();
            CreateMap<AuthorDTO,TblBookAuthor>();
        }
    }
}