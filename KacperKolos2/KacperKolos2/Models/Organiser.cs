using System.ComponentModel.DataAnnotations;

namespace KacperKolos2.Models;

public class Organiser
{
    [Key]
    public int IdOrganiser { get; set; }
    
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }
    
    public ICollection<Event_Organiser> EventOrganisers { get; set; }
}