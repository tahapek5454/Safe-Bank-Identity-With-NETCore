using Microsoft.EntityFrameworkCore;
using SafeBankIdentity.BusinessLayer.Abstract;
using SafeBankIdentity.DataAccessLayer.Abstract;
using SafeBankIdentity.DtoLayer.Dtos.CustomerAccountProcessDtos;
using SafeBankIdentity.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.BusinessLayer.Concrete
{
    public class MoneyTransferManager : IMoneyTransferService
    {
        private readonly ICustomUserService _customUserService;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;
        private readonly ICustomerAccountDal _customerAccountDal;
        public MoneyTransferManager(ICustomUserService customUserService, ICustomerAccountProcessService customerAccountProcessService, ICustomerAccountDal customerAccountDal)
        {
            _customUserService = customUserService;
            _customerAccountProcessService = customerAccountProcessService;
            _customerAccountDal = customerAccountDal;
        }

        public async Task SendMoneyToAccoutAsync(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto, string userName, string currency)
        {
            AppUser baseUser = await _customUserService.GetUserByUserNameAsync(userName);

            if (baseUser == null)
                throw new Exception("Kullanıcı Bulunamadı.");


            CustomerAccount? baseCustomerAccount = await _customerAccountDal
                .Table
                .Where(ca => ca.AppUserId == baseUser.Id && ca.CustomerAccountCurrency.Equals(currency))
                .FirstOrDefaultAsync();

            if (baseCustomerAccount == null)
                throw new Exception("Kullanıcının İlgili Hesabı Bulunamadı.");


            CustomerAccount? targetCustomerAccount = await _customerAccountDal
                .Table
                .Where(ca => ca.CustomerAccountNumber.Equals(sendMoneyForCustomerAccountProcessDto.ReceiverCustomerAccountNumber))
                .FirstOrDefaultAsync();

            if (targetCustomerAccount == null)
                throw new Exception("Hedef Hesap Bulunamadı.");


            targetCustomerAccount.CustomerAccountBalance += sendMoneyForCustomerAccountProcessDto.Amount;
            baseCustomerAccount.CustomerAccountBalance -= sendMoneyForCustomerAccountProcessDto.Amount;

            await _customerAccountProcessService.TInsertAsync(new()
            {
                Amount = sendMoneyForCustomerAccountProcessDto.Amount,
                ReceiverCustomreAccount = targetCustomerAccount,
                SenderCustomerAccount = baseCustomerAccount,
                ProcessType = "Havale",
                ProcessDate = DateTime.UtcNow,
                Description = sendMoneyForCustomerAccountProcessDto.Description,
            });


            await _customerAccountDal.SaveAsync();

        }
    }
}
