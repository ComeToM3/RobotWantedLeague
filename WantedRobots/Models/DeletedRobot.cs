
using System.ComponentModel.DataAnnotations;

namespace WantedRobots.Models;


public class DeletedRobot
{
    public int Id { get; set; }
    public string? Nom { get; set; }
    public double Poids { get; set; }
    public double Taille { get; set; }
    public string? Pays { get; set; }
}
