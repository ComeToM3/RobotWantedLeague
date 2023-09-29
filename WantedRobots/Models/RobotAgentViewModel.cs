// Models/RobotAgentViewModel.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; 


namespace WantedRobots.Models;

public class RobotAgentViewModel
{
    public IEnumerable<Robot> Robot { get; set; }
    public IEnumerable<Agent> Agent { get; set; }
}
