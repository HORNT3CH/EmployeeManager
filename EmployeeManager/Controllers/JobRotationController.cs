using EmployeeManager.Data;
using EmployeeManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManager.Controllers
{
    public class JobRotationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobRotationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var jobRotations = _context.JobRotations.Include(jr => jr.Employee);
            return View(await jobRotations.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,JobRole,RotationStartDate,RotationEndDate,Shift")] JobRotation jobRotation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobRotation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", jobRotation.EmployeeId);
            return View(jobRotation);
        }
    }

}
