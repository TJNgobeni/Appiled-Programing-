using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DisasterReliefApp.Models;
using System.Linq;

namespace DisasterReliefApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    // Dashboard showing recent incidents
    public IActionResult Index()
    {
        var incidents = _context.IncidentReports
            .OrderByDescending(i => i.ReportDate)
            .ToList();
        return View(incidents);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // GET: Create new incident report
    public IActionResult CreateIncidentReport()
    {
        return View();
    }

    // POST: Create new incident report
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateIncidentReport(IncidentReport incidentReport)
    {
        if (ModelState.IsValid)
        {
            incidentReport.ReportDate = DateTime.Now;
            _context.IncidentReports.Add(incidentReport);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(incidentReport);
    }

    // GET: Volunteer Registration
    public IActionResult VolunteerRegistration()
    {
        return View();
    }

    // POST: Volunteer Registration
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult VolunteerRegistration(Volunteer volunteer)
    {
        if (ModelState.IsValid)
        {
            _context.Volunteers.Add(volunteer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(volunteer);
    }

    // GET: Create new donation
    public IActionResult CreateDonation()
    {
        return View();
    }

    // POST: Create new donation
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateDonation(Donation donation)
    {
        if (ModelState.IsValid)
        {
            donation.DonationDate = DateTime.Now;
            _context.Donations.Add(donation);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(donation);
    }

    public IActionResult AvailableTasks()
    {
        return View();
    }
}