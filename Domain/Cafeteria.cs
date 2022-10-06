using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Cafeteria
{
    public int CafeteriaId { get; set; }
    public City City { get; set; }
    public Location Location { get; set; } 
}