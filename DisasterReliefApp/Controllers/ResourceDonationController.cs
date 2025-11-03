using Microsoft.AspNetCore.Mvc;
using DisasterReliefApp.Models;

namespace DisasterReliefApp.Controllers
{
    public class ResourceDonationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResourceDonationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /ResourceDonation/DonateResources
        public IActionResult DonateResources()
        {
            return View();
        }

        // POST: /ResourceDonation/DonateResources
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DonateResources(Donation donation)
        {
            if (ModelState.IsValid)
            {
                donation.DonationDate = DateTime.Now;
                _context.Donations.Add(donation);
                _context.SaveChanges();

                return RedirectToAction(nameof(DonationHistory));
            }
            return View(donation);
        }

        public IActionResult DonationHistory()
        {
            return View();
        }
    }
}