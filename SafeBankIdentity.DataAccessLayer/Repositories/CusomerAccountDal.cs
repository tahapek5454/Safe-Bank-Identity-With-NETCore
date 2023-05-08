﻿using SafeBankIdentity.DataAccessLayer.Abstract;
using SafeBankIdentity.DataAccessLayer.Concrete;
using SafeBankIdentity.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.DataAccessLayer.Repositories
{
    public class CusomerAccountDal : GenericRepository<CustomerAccount>, ICustomerAccountDal
    {
        public CusomerAccountDal(Context context) : base(context)
        {
        }
    }
}
