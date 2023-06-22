using Microsoft.Extensions.DependencyInjection;
using SafeBankIdentity.BusinessLayer.Abstract;
using SafeBankIdentity.BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.BusinessLayer
{
    public static class ServiceRegistration
    {
        public static void AddBusinessRegistration(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICustomerAccountProcessService, CustomerAccountProcessManager>();
            serviceCollection.AddScoped<ICustomerAccountService, CustomerAccountManager>();
            serviceCollection.AddScoped<IUserRegisterService, UserRegisterManager>();
            serviceCollection.AddScoped<IMailService, MailManager>();
            serviceCollection.AddScoped<IUserLoginService, UserLoginManager>();
            serviceCollection.AddScoped<ICustomUserService, CustomUserManager>();
            serviceCollection.AddScoped<IMoneyTransferService, MoneyTransferManager>();
            serviceCollection.AddScoped<ICurrencyService, CurrencyManager>();
        }
    }
}
