using System.Collections.Generic;

namespace libraryManagement.Repository
{
    public interface IGenericRepo<T> where T : class
    {
         T GetById(object id);  
        bool Insert(T entity);  
        bool Update(T entity);  
        bool Delete(int id);  
        IEnumerable<T> GetAll();
    }
}