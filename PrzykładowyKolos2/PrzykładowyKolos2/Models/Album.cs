using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykładowyKolos2.Models;

public class Album
{
    [Key]
    public int IdAlbum { get; set; }
    
    [MaxLength(30)]
    [Required]
    public string NazwaAlbumu { get; set; }
    
    [Required]
    public DateTime DataWydania { get; set; }
    
    public int IdWytwornia { get; set; }
    
    [ForeignKey(nameof(IdWytwornia))]
    public Wytwornia Wytwornia { get; set; }
    
    public ICollection<Utwor> Utwory { get; set; }
}