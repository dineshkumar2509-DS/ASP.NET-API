using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using libraryManagement.Repository;
using libraryManagement.Models.DTO;

namespace libraryManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {

        private readonly ITblBook _tblBook;
        private readonly IMapper _mapper;
        public BooksController(ITblBook tblBook, IMapper mapper)
        {
            this._tblBook = tblBook;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult getBooks()
        {
            try
            {
                IEnumerable<libraryManagement.Models.TblBook> data = this._tblBook.GetBooks();
                IEnumerable<BooksDTO> dtoData = _mapper.Map<IEnumerable<BooksDTO>>(data);
                return Ok(dtoData);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet("/getByID/{id}")]
        public IActionResult getBookById(int id)
        {
            try
            {
                return Ok(this._tblBook.GetBookById(id));
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet("/getByName/{name}")]
        public IActionResult getBookByName(string name)
        {
            try
            {
                IEnumerable<libraryManagement.Models.TblBook> books = this._tblBook.GetBooksByName(name);
                IEnumerable<BooksDTO> dtoData = _mapper.Map<IEnumerable<BooksDTO>>(books);
                return Ok(dtoData);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult addBook(BooksDTO book)
        {
            try
            {
                var entity = _mapper.Map<BooksDTO, libraryManagement.Models.TblBook>(book);
                return Ok(this._tblBook.InsertBook(entity));
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpDelete("/delete/{id}")]
        public IActionResult deleteById(int id)
        {
            try
            {
                return Ok(this._tblBook.DeleteBook(id));
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut("/update")]
        public IActionResult UpdateById(BooksDTO book)
        {
            try
            {
                var entity = _mapper.Map<BooksDTO, libraryManagement.Models.TblBook>(book);
                return Ok(this._tblBook.UpdateBook(entity));
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}