using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMRentACar.Infrastructure.Data;
using PMRentACarII.Infrastructure.Data.Configuration;

namespace PMRentACarII.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AgentConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new DriverConfiguration());
            builder.ApplyConfiguration(new RentConfiguration());

            builder.Entity<UserCar>().HasKey(x => new { x.UserId, x.CarId });

            base.OnModelCreating(builder);
        }

        public DbSet<Agent> Agents { get; set; } = null!;

        public DbSet<Car> Cars { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Driver> Drivers { get; set; } = null!;

        public DbSet<Rent> Rents { get; set; } = null!;

        public DbSet<UserCar> UsersCars { get; set; } = null!;


    }
}