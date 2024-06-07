using System.ComponentModel.DataAnnotations;

namespace PrzykładowyKolos2.Models;

public class Wytwornia
{
    [Key]
    public int IdWytwornia { get; set; }
    
    [MaxLength(50)]
    [Required]
    public string Nazwa { get; set; }
    
    public ICollection<Album> Albumy { get; set; }
}