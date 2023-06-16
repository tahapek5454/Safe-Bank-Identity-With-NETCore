using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.DtoLayer.Dtos.CustomerAccountProcessDtos
{
    public class SendMoneyForCustomerAccountProcessDto
    {
        public decimal Amount { get; set; }
        public string ReceiverCustomerAccountNumber { get; set; }
        public string? Description { get; set; }

    }
}
