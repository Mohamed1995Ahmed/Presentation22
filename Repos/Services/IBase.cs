using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos.Services
{
    public interface IBase< T> where T : class
    {
        Task Add(T entity);
        Task Delete(int id);
        Task update(T entity);
        Task<IEnumerable<T>> GetAll();
        Task <T> getbyid(int id);
        Task Save();

    }
}
