// RobotController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WantedRobots.Models;

public class RobotController : Controller
{
    private readonly ApplicationDbContext _context;

    public RobotController(ApplicationDbContext context)
    {
        _context = context;
    }
   public IActionResult Index()
{
    var robots = _context.Robots.ToListAsync();

    return View(robots);
}


    // Action pour afficher la liste des robots et les agents
    public async Task<IActionResult> List()
{
    var robots = await _context.Robots.ToListAsync();
    var agents = await _context.Agents.ToListAsync();

foreach (var robot in robots)
    {
        // Recherchez l'agent correspondant en fonction du continent du robot.
        var matchingAgent = agents.FirstOrDefault(agent => agent.Continent == robot.Continent);

        // Si un agent correspondant est trouvé, attribuez-le au robot.
        if (matchingAgent != null)
        {
            robot.AgentId = matchingAgent.Id; // Assurez-vous que votre modèle Robot a une propriété AgentId.
        }
    }



    var viewModel = new RobotAgentViewModel
    {
        Robot = robots,
        Agent = agents
    };

    return View(viewModel);
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> AssocierAgentARobot(int robotId, int agentId, string commentaire)
{
    var robot = await _context.Robots.FindAsync(robotId);
    var agent = await _context.Agents.FindAsync(agentId);

    if (robot != null && agent != null)
    {
        robot.AgentId = agent.Id;
        robot.Commentaire = commentaire;

        await _context.SaveChangesAsync();
    }

    // Rechargez la vue avec les données mises à jour
    var robots = await _context.Robots.ToListAsync();
    var agents = await _context.Agents.ToListAsync();

    var viewModel = new RobotAgentViewModel
    {
        Robot = robots,
        Agent = agents
    };

    return View("List", viewModel);
}

    
    // Action pour afficher le formulaire de création d'un robot
    public IActionResult Create()
    {
        return View();
    }

    // Action pour traiter la création d'un robot
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Robot robot)
    {
        if (ModelState.IsValid)
        {
            _context.Add(robot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }
        return View(robot);
    }

    // Action HTTP GET pour afficher le formulaire de modification
    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var robot = await _context.Robots.FindAsync(id);
        if (robot == null)
        {
            return NotFound();
        }

        return View(robot);
    }

    // Action HTTP POST pour traiter la soumission du formulaire de modification
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Robot robot)
    {
        if (id != robot.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(robot);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RobotExists(robot.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(List));
        }
        return View(robot);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var robot = await _context.Robots.FindAsync(id);

        if (robot == null)
        {
            return NotFound();
        }

        // Créez un objet DeletedRobot à partir des données du robot à supprimer
        var deletedRobot = new DeletedRobot
        {
            Id = robot.Id,
            Nom = robot.Nom,
            Poids = robot.Poids,
            Taille = robot.Taille,
            Pays = robot.Pays
        };

        // Ajoutez l'élément supprimé à la table des éléments supprimés
        _context.DeletedRobots.Add(deletedRobot);
        await _context.SaveChangesAsync();

        // Supprimez l'élément de la table principale
        _context.Robots.Remove(robot);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(List));
    }



    // Vérifie si un robot existe en fonction de son ID
    private bool RobotExists(int id)
    {
        return _context.Robots.Any(e => e.Id == id);
    }


}



