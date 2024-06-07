using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrzykładowyKolos2.Models;

public class Utwor
{
    [Key]
    public int IdUtwor { get; set; }
    
    [MaxLength(30)]
    [Required]
    public string NazwaUtworu { get; set; }
    
    [Required]
    public float CzasTrwania { get; set; }

    public int? IdAlbum { get; set; }

    [ForeignKey(nameof(IdAlbum))]
    public Album Albumy { get; set; }
    
    public ICollection<Muzyk> Muzycy { get; set; }
}