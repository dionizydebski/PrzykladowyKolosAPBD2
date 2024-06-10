using KacperKolos2.Models;
using Microsoft.EntityFrameworkCore;

namespace KacperKolos2.Context;

public partial class ApbdContext : DbContext
{
    public ApbdContext() {}

    public ApbdContext(DbContextOptions<ApbdContext> options) : base(options) {}
    
    public DbSet<Event> Events { get; set; }
    public DbSet<Organiser> Organisers { get; set; }
    public DbSet<Event_Organiser> EventOrganisers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<Event_Organiser>()
            .HasKey(eo => new { eo.IdEvent, eo.IdOrganiser });
        
        modelBuilder.Entity<Event_Organiser>()
            .HasOne(eo => eo.Event)
            .WithMany(e => e.EventOrganisers)
            .HasForeignKey(eo => eo.IdEvent);
        
        modelBuilder.Entity<Event_Organiser>()
            .HasOne(eo => eo.Organiser)
            .WithMany(e => e.EventOrganisers)
            .HasForeignKey(eo => eo.IdOrganiser);
    }
}