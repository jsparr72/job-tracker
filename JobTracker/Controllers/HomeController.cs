using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using JobTracker.Models;

namespace JobTracker.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Overview()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [Authorize] // Can only be accessed when logged in
    public IActionResult Applications()
    {
        var ApplicationsTable = _context.Job_Applications.ToList();
        return View(ApplicationsTable);
    }

    public IActionResult CreateApplication()
    {
        return View();
    }

    public IActionResult EditApplication(int ID)
    {
        var applicationInDatabase = _context.Job_Applications.SingleOrDefault(application => application.ID == ID);
        return View(applicationInDatabase);
    }

    public IActionResult DeleteApplication(int ID)
    {
        var applicationInDatabase = _context.Job_Applications.SingleOrDefault(application => application.ID == ID);
        _context.Job_Applications.Remove(applicationInDatabase);
        _context.SaveChanges();
        return RedirectToAction("Applications");
    }

    public IActionResult NewApplication(JobApplication model) // When a new application is submitted through form
    {
        _context.Job_Applications.Add(model);
        _context.SaveChanges();
        return RedirectToAction("Applications");
    }

    public IActionResult ModifyApplication(JobApplication model) // When an application is being edited
    {
        _context.Job_Applications.Update(model);
        _context.SaveChanges();
        return RedirectToAction("Applications");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}