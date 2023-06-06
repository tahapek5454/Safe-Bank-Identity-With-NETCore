using SafeBankIdentity.DtoLayer.Dtos.CustomerAccountProcessDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.BusinessLayer.Abstract
{
    public interface IMoneyTransferService
    {
        Task SendMoneyToAccoutAsync(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto, string userName);
    }
}
