using Microsoft.EntityFrameworkCore;
using SafeBankIdentity.DataAccessLayer.Abstract;
using SafeBankIdentity.DataAccessLayer.Concrete;
using SafeBankIdentity.EntityLayer.Concrete.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T>
        where T : BaseEntity
    {
        private readonly Context _context;
        public GenericRepository(Context context)
        {
            _context= context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            Table.Remove(entity);
        }

        public IQueryable<T> GetAll()
            => Table.AsQueryable();


        public T GetById(int id)
            => Table.FirstOrDefault(x => x.Id == id);

        public async Task<T> GetByIdAsync(int id)
            => await Table.FirstOrDefaultAsync(x => x.Id == id);
        

        public void Insert(T entity)
            => Table.Add(entity);

        public async Task InsertAsync(T entity)
            => await Table.AddAsync(entity);

        public int Save()
            => _context.SaveChanges();

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public void Update(T entity)
            => Table.Update(entity);

    }
}
