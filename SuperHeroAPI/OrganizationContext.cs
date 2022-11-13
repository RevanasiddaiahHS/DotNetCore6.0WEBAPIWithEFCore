using Microsoft.EntityFrameworkCore;

namespace SuperHeroAPI
{
    public class OrganizationContext:DbContext
    {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=LAPTOP-VT657LCV\SQLEXPRESS;database=superherodb;trusted_connection=true");
        }
        public DbSet<SuperHero> superhero { get; set; }
    }
}
