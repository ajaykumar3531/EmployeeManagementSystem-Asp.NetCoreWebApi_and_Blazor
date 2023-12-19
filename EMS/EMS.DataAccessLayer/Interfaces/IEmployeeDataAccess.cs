using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.DataAccessLayer.Interfaces
{
    public interface IEMSDataAccess<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T data);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        Task<bool> SaveChangesAsync();
        Task<string> FindByEmailAsync(string email);
    }

}
