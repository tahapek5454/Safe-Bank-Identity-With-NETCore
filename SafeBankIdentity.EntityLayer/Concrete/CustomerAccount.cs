using SafeBankIdentity.EntityLayer.Concrete.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.EntityLayer.Concrete
{
    public class CustomerAccount: BaseEntity
    {
        public string CustomerAccountNumber { get; set; }
        public string CustomerAccountCurrency { get; set; }
        public decimal CustomerAccountBalance { get; set; }
        public string BankBranch { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<CustomerAccountProcess> SenderCustomerAccountProcesses { get; set; } 
        public List<CustomerAccountProcess> ReceiverCustomerAccountProcesses { get; set; }
    }
}
