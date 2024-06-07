using Microsoft.EntityFrameworkCore;
using PrzykładowyKolos2.Models;

namespace PrzykładowyKolos2.Context;

public partial class ApbdContext : DbContext
{
    public ApbdContext() {}

    public ApbdContext(DbContextOptions<ApbdContext> options) : base(options) {}
    
    public DbSet<Muzyk> Muzycy { get; set; }
    
    public DbSet<Utwor> Utwory { get; set; }
    
    public DbSet<Album> Albumy { get; set; }
    
    public DbSet<Wytwornia> Wytwornie { get; set; }
}