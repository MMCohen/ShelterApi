using Microsoft.EntityFrameworkCore;
using ShelterApi.Model;

namespace ShelterApi.Data;

public class SheltersDbContext : DbContext
{
    public SheltersDbContext(DbContextOptions<SheltersDbContext> options)
        : base(options)
    {
    }


    public DbSet<Area> Areas { get; set; }
    public DbSet<Shelter> Shelters { get; set; }
    public DbSet<Inspection> Inspections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Shelter>()
            .Property(s => s.ShelterType)
            .HasConversion<string>();


        modelBuilder.Entity<Shelter>()
            .HasOne(s => s.Area)
            .WithMany(a => a.Shelters)
            .HasForeignKey(s => s.AreaId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Inspection>()
            .HasOne(i => i.Shelter)
            .WithMany(s => s.Inspections)
            .HasForeignKey(i => i.ShelterId)
            .OnDelete(DeleteBehavior.Cascade);

            

        //modelBuilder.Entity<Area>()
        //    .HasMany(a => a.Shelters)
        //    .WithOne(s => s.Area)
        //    .HasForeignKey(s => s.AreaId);

        //modelBuilder.Entity<Shelter>()
        //    .HasMany(s => s.Inspections)
        //    .WithOne(i => i.Shelter)
        //    .HasForeignKey(i => i.ShelterId);
    }
}

