using Microsoft.EntityFrameworkCore;
using SafeBankIdentity.EntityLayer.Concrete.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.DataAccessLayer.Abstract
{
    public interface IGenericDal<T>
        where T : BaseEntity
    {
        public DbSet<T> Table { get; }
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(int id);
        IQueryable<T> GetAll();
        int Save();

        Task InsertAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<int> SaveAsync();

       
    }
}
