using System;
using System.Collections.Generic;
using System.Linq;
namespace libraryManagement.Repository
{
    public class TblBook : ITblBook
    {
        private readonly IGenericRepo<libraryManagement.Models.TblBook> _tblBook;
        public TblBook(IGenericRepo<libraryManagement.Models.TblBook> tblBook)
        {
            this._tblBook = tblBook;
        }
        public libraryManagement.Models.TblBook GetBookById(int id)
        {
            try
            {
                return this._tblBook.GetById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool InsertBook(libraryManagement.Models.TblBook book)
        {
            try
            {
                return this._tblBook.Insert(book);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateBook(libraryManagement.Models.TblBook book)
        {
            try
            {
                return this._tblBook.Update(book);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool DeleteBook(int id)
        {
            try
            {
                return this._tblBook.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<libraryManagement.Models.TblBook> GetBooks()
        {
            try
            {
                return this._tblBook.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<libraryManagement.Models.TblBook> GetBooksByName(string name)
        {
            try
            {
                IEnumerable<libraryManagement.Models.TblBook> books = this._tblBook.GetAll();
                return (books.Where(item => item.BookTitle.ToLower().Contains(name)));
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}