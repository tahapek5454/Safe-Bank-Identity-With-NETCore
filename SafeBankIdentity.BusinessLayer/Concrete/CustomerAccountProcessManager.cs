using SafeBankIdentity.BusinessLayer.Abstract;
using SafeBankIdentity.DataAccessLayer.Abstract;
using SafeBankIdentity.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.BusinessLayer.Concrete
{
    public class CustomerAccountProcessManager : ICustomerAccountProcessService
    {
        private readonly ICustomerAccountProcessDal _customerAccountProcessDal;

        public CustomerAccountProcessManager(ICustomerAccountProcessDal customerAccountProcessDal)
        {
            _customerAccountProcessDal = customerAccountProcessDal;
        }

        public void TDelete(CustomerAccountProcess entity)
            => _customerAccountProcessDal.Delete(entity);

        public async Task TDeleteAsync(int id)
            => await _customerAccountProcessDal.DeleteAsync(id);

        public IQueryable<CustomerAccountProcess> TGetAll()
            => _customerAccountProcessDal.GetAll();

        public CustomerAccountProcess TGetById(int id)
            => _customerAccountProcessDal.GetById(id);

        public async Task<CustomerAccountProcess> TGetByIdAsync(int id)
            => await _customerAccountProcessDal.GetByIdAsync(id);

        public void TInsert(CustomerAccountProcess entity)
            => _customerAccountProcessDal.Insert(entity);

        public async Task TInsertAsync(CustomerAccountProcess entity)
            => await _customerAccountProcessDal.InsertAsync(entity);

        public int TSave()
            => _customerAccountProcessDal.Save();

        public async Task<int> TSaveAsync()
            => await _customerAccountProcessDal.SaveAsync();

        public void TUpdate(CustomerAccountProcess entity)
            => _customerAccountProcessDal.Update(entity);
    }
}
