using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete;

public class Context : IdentityDbContext<AppUser, AppRole, int>
{
    // No need to give AppUser or AppRole since they replace IdentityUser and IdentityRole

    public DbSet<CustomerAccount> CustomerAccounts { get; set; }

    public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433; Initial Catalog=EasyCashDb; integrated Security=false; User ID='sa'; Password=Password123!; trustServerCertificate=true");
    }
}