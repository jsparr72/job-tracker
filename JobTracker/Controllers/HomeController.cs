using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using JobTracker.ViewModels;
using JobTracker.Models;

namespace JobTracker.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _UserManager;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context,
    UserManager<User> _UserManager)
    {
        _logger = logger;
        _context = context;
        this._UserManager = _UserManager;
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
    public async Task<IActionResult> Applications()
    {
        var userId = _UserManager.GetUserId(User);
        var ApplicationsTable = await _context.JobApplications.
        Where(application => application.UserId == userId).ToListAsync();

        return View(ApplicationsTable);
    }

    [Authorize]
    public IActionResult CreateApplication()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateApplication(CreateApplicationViewModel model)
    {
        if (ModelState.IsValid)
        {
            var id = _UserManager.GetUserId(User);
            var application = new JobApplication
            {
                UserId = id,
                Company = model.Company,
                JobTitle = model.JobTitle,
                Status = model.Status,
                ApplicationDate = model.ApplicationDate,
                Salary = model.Salary,
                Notes = string.IsNullOrWhiteSpace(model.Notes) ? null : model.Notes,
            };
            _context.JobApplications.Add(application);
            await _context.SaveChangesAsync();
            return RedirectToAction("Applications");
        }
        else
        {
            ModelState.AddModelError("", "Something went wrong, try again");
            return View(model);
        }
    }

    [Authorize]
    public IActionResult EditApplication(int ID)
    {
        var userId = _UserManager.GetUserId(User);
        var appInDatabase = _context.JobApplications.SingleOrDefault(application => application.ID == ID);

        if (appInDatabase == null)
        {
            return NotFound();
        }

        var model = new CreateApplicationViewModel // retrieve info to start form with
        {
            Company = appInDatabase.Company,
            JobTitle = appInDatabase.JobTitle,
            Status = appInDatabase.Status,
            ApplicationDate = appInDatabase.ApplicationDate,
            Salary = appInDatabase.Salary,
            Notes = appInDatabase.Notes
        };

        return View(model);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> EditApplication(CreateApplicationViewModel model, int ID)
    {
   
        if (ModelState.IsValid)
        {
            var userId = _UserManager.GetUserId(User);
            var appInDatabase = _context.JobApplications.SingleOrDefault(application => application.ID == ID);

            if (appInDatabase == null)
            {
                return NotFound(); // Somehow the wrong application id was sent in
            }
            else if (appInDatabase.UserId != userId)
            {
                return Unauthorized(); // User does not own the application trying to be edited
            }

            {
                appInDatabase.UserId = userId;
                appInDatabase.Company = model.Company;
                appInDatabase.JobTitle = model.JobTitle;
                appInDatabase.Status = model.Status;
                appInDatabase.ApplicationDate = model.ApplicationDate;
                appInDatabase.Salary = model.Salary;
                appInDatabase.Notes = string.IsNullOrWhiteSpace(model.Notes) ? null : model.Notes;
            };
            _context.JobApplications.Update(appInDatabase);
            await _context.SaveChangesAsync();
            return RedirectToAction("Applications");
        }
        else
        {
            ModelState.AddModelError("", "Something went wrong, try again");
            return View(model);
        }
    }

    [Authorize]
    public IActionResult DeleteApplication(int ID)
    {
        var applicationInDatabase = _context.JobApplications.SingleOrDefault(application => application.ID == ID);
        _context.JobApplications.Remove(applicationInDatabase);
        _context.SaveChanges();
        return RedirectToAction("Applications");
    }

    public IActionResult ModifyApplication(JobApplication model) // When an application is being edited
    {
        _context.JobApplications.Update(model);
        _context.SaveChanges();
        return RedirectToAction("Applications");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}