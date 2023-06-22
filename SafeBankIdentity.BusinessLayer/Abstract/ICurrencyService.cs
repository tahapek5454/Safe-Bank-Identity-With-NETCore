using SafeBankIdentity.DtoLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.BusinessLayer.Abstract
{
    public interface ICurrencyService
    {
        Task<string> GetCurrencyValueAsync(CurrencyEnum currency);
    }
}
