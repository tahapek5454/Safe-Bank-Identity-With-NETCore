using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.BusinessLayer.Abstract
{
    public interface IGenericService<T>
        where T : class
    {
        void TInsert(T entity);
        void TUpdate(T entity);
        void TDelete(T entity);
        T TGetById(int id);
        IQueryable<T> TGetAll();
        int TSave();

        Task TInsertAsync(T entity);
        Task TDeleteAsync(int id);
        Task<T> TGetByIdAsync(int id);
        Task<int> TSaveAsync();
    }
}
