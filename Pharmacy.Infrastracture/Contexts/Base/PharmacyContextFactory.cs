using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pharmacy.Infrastructure.Contexts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmacy.Infrastracture.Contexts.Base
{
    public class PharmacyContextFactory : IDesignTimeDbContextFactory<PharmacyContext>
    {
        public IConfiguration Configuration { get; }

        public PharmacyContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public PharmacyContextFactory()
        {

        }
        public PharmacyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PharmacyContext>();
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=160048; Integrated Security = true");

            return new PharmacyContext(optionsBuilder.Options);
        }
    }
}
