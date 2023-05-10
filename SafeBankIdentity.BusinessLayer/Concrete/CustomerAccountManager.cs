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
    public class CustomerAccountManager : ICustomerAccountService
    {
        private readonly ICustomerAccountDal _customerAccountDal;

        public CustomerAccountManager(ICustomerAccountDal customerAccountDal)
        {
            _customerAccountDal = customerAccountDal;
        }

        public void TDelete(CustomerAccount entity)
            => _customerAccountDal.Delete(entity);

        public async Task TDeleteAsync(int id)
            => await _customerAccountDal.DeleteAsync(id);

        public IQueryable<CustomerAccount> TGetAll()
            => _customerAccountDal.GetAll();

        public CustomerAccount TGetById(int id)
            => _customerAccountDal.GetById(id);

        public async Task<CustomerAccount> TGetByIdAsync(int id)
            => await _customerAccountDal.GetByIdAsync(id);

        public void TInsert(CustomerAccount entity)
            => _customerAccountDal.Insert(entity);

        public async Task TInsertAsync(CustomerAccount entity)
            => await _customerAccountDal.InsertAsync(entity);

        public int TSave()
            => _customerAccountDal.Save();

        public async Task<int> TSaveAsync()
            => await _customerAccountDal.SaveAsync();

        public void TUpdate(CustomerAccount entity)
            => _customerAccountDal.Update(entity);
    }
}
