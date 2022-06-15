using Microsoft.EntityFrameworkCore;
namespace RestaurantAPI2.Entities
{
    public class RestaurantDbContext : DbContext
    {
        private string _connectionString =
            "Server=DESKTOP-ESJ2ABO;Database=RestaurantDb;Trusted_Connection=True;";
        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<Address> adresses { get; set; }
        public DbSet<Dish> dishes { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()         //Tutaj wyznaczasz co w encjach ma byc must have!
                .Property(e => e.Email)
                .IsRequired();

            modelBuilder.Entity<User>()         //Tutaj wyznaczasz co w encjach ma byc must have!
                .Property(e => e.DateOfBirth)
                .IsRequired(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Nationality)
                .IsRequired(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsRequired();

            modelBuilder.Entity<Restaurant>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Dish>()
                .Property(e => e.Name)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(e => e.City)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Address>()
                .Property(e => e.Street)
                .IsRequired()
                .HasMaxLength(50);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }
}
