using LightInEveryHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace LightInEveryHouse.Data
{
    public class ApiDbContext : DbContext
    {

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().ToTable("Address");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(g => g.Group)
                    .WithMany(a => a.Addresses)
                    .HasForeignKey(x => x.GroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("Blackout_Schedule");

                entity.HasMany(s => s.Schedules)
                    .WithOne(a => a.Address)
                    .HasForeignKey(x => x.AddressId);
            });
        }

    }
}
