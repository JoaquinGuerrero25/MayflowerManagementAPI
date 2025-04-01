using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(string id);
        IEnumerable<T> GetAll();
        T Create(T entity);
        T Update(T entity);
        T Delete(string id);
    }
}
