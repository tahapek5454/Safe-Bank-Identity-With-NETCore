using SafeBankIdentity.EntityLayer.Concrete.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.EntityLayer.Concrete
{
    public class CustomerAccountProcess: BaseEntity
    {
        public string ProcessType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ProcessDate { get; set; }

        public int SenderCustomerAccountId { get; set; }
        public int ReceiverCustomerAccountId { get; set; }
        public CustomerAccount SenderCustomerAccount { get; set; }
        public CustomerAccount ReceiverCustomreAccount { get; set; }

    }
}
