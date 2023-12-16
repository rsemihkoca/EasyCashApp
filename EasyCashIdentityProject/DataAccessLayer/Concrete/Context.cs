using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Options;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433; Initial Catalog=EasyCashDb; integrated Security=false; User ID='sa'; Password=Password123!; trustServerCertificate=true");

        }

        public DbSet<CustomerAccount> CustomerAccounts { get; set; }

        public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }


    }
}