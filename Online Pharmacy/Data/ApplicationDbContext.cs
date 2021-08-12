using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Online_Pharmacy.Models;

namespace Online_Pharmacy.Data
{
    public class ApplicationDbContext : IdentityDbContext<SiteUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MedicalSupply> MedicalSupplies { get; set; }
        public DbSet<SiteUser> SiteUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb;Initial Catalog=OnlinePharmacy;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
