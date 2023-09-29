// Models/Agent.cs

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; 

namespace WantedRobots.Models;

public class Agent
{
    public int Id { get; set; }

    public string? NomAgent { get; set; }
    public double Identification { get; set; }
    public string? Continent { get; set; }

}

