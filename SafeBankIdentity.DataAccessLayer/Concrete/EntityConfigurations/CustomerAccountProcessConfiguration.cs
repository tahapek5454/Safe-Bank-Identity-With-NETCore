using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeBankIdentity.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.DataAccessLayer.Concrete.EntityConfigurations
{
    public class CustomerAccountProcessConfiguration : IEntityTypeConfiguration<CustomerAccountProcess>
    {
        public void Configure(EntityTypeBuilder<CustomerAccountProcess> builder)
        {
            builder.HasOne(cap => cap.SenderCustomerAccount)
                .WithMany(ca => ca.SenderCustomerAccountProcesses)
                .HasForeignKey(cap => cap.SenderCustomerAccountId);

            builder.HasOne(cap => cap.ReceiverCustomreAccount)
                .WithMany(ca => ca.ReceiverCustomerAccountProcesses)
                .HasForeignKey(cap => cap.ReceiverCustomerAccountId);
        }
    }
}
