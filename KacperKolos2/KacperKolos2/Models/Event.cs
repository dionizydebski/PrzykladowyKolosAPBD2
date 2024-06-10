using System.ComponentModel.DataAnnotations;

namespace KacperKolos2.Models;

public class Event
{
    [Key]
    public int IdEvent { get; set; }
    
    [MaxLength(60)]
    [Required]
    public string Name { get; set; }
    
    [Required]
    public DateTime DateFro { get; set; }
    
    public DateTime? DateTo { get; set; }
    
    public ICollection<Event_Organiser> EventOrganisers { get; set; }
}