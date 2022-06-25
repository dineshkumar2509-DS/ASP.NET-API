using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

using libraryManagement.Models.DTO;
using libraryManagement.Models;


namespace libraryManagement.Repository
{
    public class BookCopy : IBookCopy
    {
        private readonly IGenericRepo<TblBookCopy> _tblBookCopy;
        private readonly IGenericRepo<libraryManagement.Models.TblBook> _tblBook;
        private readonly IGenericRepo<TblBookAuthor> _tblBookAuthor;

        private readonly LibraryContext _libraryContext;

        private readonly IMapper _mapper;
        public BookCopy(IGenericRepo<libraryManagement.Models.TblBook> tblBook, IGenericRepo<TblBookCopy> tblBookCopy,IGenericRepo<TblBookAuthor> tblBookAuthor,IMapper mapper,LibraryContext libraryContext)
        {
            this._tblBook = tblBook;
            this._tblBookCopy = tblBookCopy;
            this._tblBookAuthor=tblBookAuthor;
            this._libraryContext=libraryContext;
            this._mapper = mapper;
        }

        public BookCopyDTO GetBookWithCopy(int Id)
        {
            return new BookCopyDTO();
        }

        public bool InsertBookWithCopy(BookCopyDTO bookCopy)
        {
            try
            {
                libraryManagement.Models.TblBook bookEntity = this._mapper.Map<BookCopyDTO, libraryManagement.Models.TblBook>(bookCopy);
                TblBookCopy tblBookCopy = this._mapper.Map<BookCopyDTO, TblBookCopy>(bookCopy);
                this._tblBook.Insert(bookEntity);
                int lastID = this._tblBook.GetAll().Select(item=>item.BookBookId).DefaultIfEmpty().Max();
                tblBookCopy.BookCopiesBookId=lastID;
                this._tblBookCopy.Insert(tblBookCopy);
                foreach(var item in bookCopy.Authors){
                    item.BookAuthorsBookId=lastID;
                    TblBookAuthor author = this._mapper.Map<AuthorDTO,TblBookAuthor>(item);
                    this._tblBookAuthor.Insert(author);
                }
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public BookCopyDTO GetBookDetails(int Id){
            try
            {
                libraryManagement.Models.TblBook tblBook = this._tblBook.GetById(Id);
                BookCopyDTO bookCopyDTO = this._mapper.Map<libraryManagement.Models.TblBook,BookCopyDTO>(tblBook);
                TblBookCopy tblBookCopy = this._tblBookCopy.GetById(bookCopyDTO.BookBookId);
                TblBookAuthor tblBookAuthor = this._tblBookAuthor.GetById(bookCopyDTO.BookBookId);

                return new BookCopyDTO();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}