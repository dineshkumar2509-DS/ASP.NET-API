using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using libraryManagement.Models;

namespace libraryManagement.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {

        private readonly LibraryContext _libraryContext;

        public GenericRepo(LibraryContext libraryContext)
        {
            this._libraryContext = libraryContext;
        }

        public T GetById(object id)
        {
            try
            {
                return this._libraryContext.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(T entity)
        {
            try
            {
                this._libraryContext.Set<T>().Add(entity);
                this._libraryContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                this._libraryContext.Set<T>().Attach(entity);
                this._libraryContext.Entry(entity).State = EntityState.Modified;
                this._libraryContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                T data = this._libraryContext.Set<T>().Find(id);
                this._libraryContext.Set<T>().Remove(data);
                this._libraryContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return this._libraryContext.Set<T>();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }
}