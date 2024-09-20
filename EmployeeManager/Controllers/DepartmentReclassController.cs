using EmployeeManager.Data;
using EmployeeManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManager.Controllers
{
    public class DepartmentReclassController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentReclassController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var reclassHours = _context.DepartmentReclasses
                                .Include(dr => dr.Department)
                                .Include(dr => dr.Employee);
            return View(await reclassHours.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentId,EmployeeId,ReclassHours,ReclassDate")] DepartmentReclass departmentReclass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentReclass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", departmentReclass.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", departmentReclass.EmployeeId);
            return View(departmentReclass);
        }
    }

}
