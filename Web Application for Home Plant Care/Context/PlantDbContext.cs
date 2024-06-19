using Microsoft.EntityFrameworkCore;

namespace Web_Application_for_Home_Plant_Care.Models
{
    public class PlantDbContext : DbContext
    {
        public PlantDbContext(DbContextOptions<PlantDbContext> options) : base(options) { }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantCare> PlantCares { get; set; }
        public DbSet<PlantType> PlantTypes { get; set; }
        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>(entity =>
            {
                entity.HasKey(e => e.PlantID);

                entity.HasOne(p => p.PlantType)
                .WithMany(pt => pt.Plants)
                .HasForeignKey(p => p.PlantTypeID);
            });


            modelBuilder.Entity<PlantCare>(entity => 
            {
                entity.HasKey(p => p.CareID);

                entity.HasOne(pc => pc.Plant)
                .WithMany(p => p.PlantCares)
                .HasForeignKey(pc => pc.PlantID);
            });

            modelBuilder.Entity<Reminder>(entity =>
            {
                entity.HasKey(p => p.ReminderID);

                entity.HasOne(r => r.Plant)
                .WithMany(p => p.Reminders)
                .HasForeignKey(r => r.PlantID);
            });
            modelBuilder.Entity<PlantType>(entity => 
            {
                entity.HasKey(t => t.PlantTypeID);
            });
        }
    }
}
