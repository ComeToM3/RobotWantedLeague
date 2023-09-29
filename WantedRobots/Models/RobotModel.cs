// Models/Robot.cs

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; 
namespace WantedRobots.Models;

public class Robot
{
    public int Id { get; set; }

    [Required]
    public string? Nom { get; set; }

    [Required]
    public double Poids { get; set; }

    [Required]
    public double Taille { get; set; }

    [Required]
    public string? Pays { get; set; }
    
    public string? Continent { get; set; } // Ajoutez cette propriété pour le continent

        public string? Commentaire { get; set; } // Commentaire de l'agent

        public int? AgentId { get; set; } // ID de l'agent associé


}
