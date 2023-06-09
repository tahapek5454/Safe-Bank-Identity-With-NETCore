﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafeBankIdentity.DataAccessLayer.Abstract;
using SafeBankIdentity.DataAccessLayer.Concrete;
using SafeBankIdentity.DataAccessLayer.IdentityCustomValidator.CustomeIdentityValidationRules;
using SafeBankIdentity.DataAccessLayer.Repositories;
using SafeBankIdentity.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.DataAccessLayer
{
	public static class ServiceRegistration
    {
        public static void AddDataAccessRegistration(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<Context>(options => options.UseNpgsql(configuration["ConnectionStrings:PostgreSQL"]));
            serviceCollection.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<Context>()
                .AddErrorDescriber<CustomeIdentityValidator>()
                .AddDefaultTokenProviders();

            serviceCollection.AddScoped<ICustomerAccountDal, CusomerAccountDal>();

            serviceCollection.AddScoped<ICustomerAccountProcessDal, CustomerAccountProcessDal>();
        }
    }
}
