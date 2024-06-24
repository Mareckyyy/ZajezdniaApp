using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wyjazdy.Models;

namespace Wyjazdy.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
             
        }

        public DbSet<Order>? Wyjazdy { get; set; }
        public DbSet<Przedmiot>? Pojazdy { get; set; }

       protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Order>(o =>
            {
                o.Property(o => o.dataZlozenia)
                .HasDefaultValueSql("GETDATE()");
            });
            builder.Entity <Przedmiot>(p =>
            {
                p.HasIndex(p => p.NazwaTramwaju)
                .IsUnique();
            });

        }


        
    }
}
