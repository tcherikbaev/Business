using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Business.Models;

namespace Business.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly BusinessContext _context;

        EmployeesDataAccessLayer employeesDataAccessLayer = null;
        //public EmployeesController()
        //{
        //   employeesDataAccessLayer = new EmployeesDataAccessLayer();

        //}
        public EmployeesController(BusinessContext context)
        {
            _context = context;
            employeesDataAccessLayer = new EmployeesDataAccessLayer();
        }

        // GET: Employees
        public ActionResult Index()
        {
            IEnumerable<Employees> employees = employeesDataAccessLayer.GetAll();
            employees = _context.Employees.Include(e => e.DoljnostNavigation);
              return View (employees);
        }
        //public async Task<IActionResult> Index(string searchString)
        //{
        //    IQueryable<Employees> movies = null;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        movies = _context.Employees.Where(m => m.Name.Contains(searchString)
        //        || m.Address.Contains(searchString)).Include(e => e.DoljnostNavigation);
        //    }
        //    else
        //    {
        //        movies = _context.Employees.Include(e => e.DoljnostNavigation);
        //    }

        //    return View(await movies.ToListAsync());
        //}

        public ActionResult Details(byte id)
        {
            Employees employees =employeesDataAccessLayer.GetEmployee(id) ;
            ViewData["Doljnost"] = new SelectList(_context.Doljnost, "Id", "Doljnost1", employees.Doljnost);

            return View(employees);
        }
        //public async Task<IActionResult> Details(byte? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employees = await _context.Employees
        //        .Include(e => e.DoljnostNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (employees == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employees);
        //}

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["Doljnost"] = new SelectList(_context.Doljnost, "Id", "Doljnost1");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Doljnost,Salary,Address,Telephone")] Employees employees)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(employees);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Doljnost"] = new SelectList(_context.Doljnost, "Id", "Id", employees.Doljnost);
        //    return View(employees);
        //}
        public IActionResult Create(Employees employees)
        {
            try
            {
                employeesDataAccessLayer.Addemployee(employees);
               
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                return View();
            }
        }
        // GET: Employees/Edit/5
        //public async Task<IActionResult> Edit(byte? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employees = await _context.Employees.FindAsync(id);
        //    if (employees == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["Doljnost"] = new SelectList(_context.Doljnost, "Id", "Doljnost1", employees.Doljnost);
        //    return View(employees);
        //}
        public ActionResult Edit(byte id)
        {
            Employees employees = employeesDataAccessLayer.DetailsEmployee(id);
            ViewData["Doljnost"] = new SelectList(_context.Doljnost, "Id", "Doljnost1");
            return View(employees);
        }
        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employees employees)
        {
            try
            {
                // TODO: Add update logic here  
                employeesDataAccessLayer.UpdateEmployee(employees);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> Edit(byte id, [Bind("Id,Name,Doljnost,Salary,Address,Telephone")] Employees employees)
        //{
        //    if (id != employees.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(employees);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!EmployeesExists(employees.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Doljnost"] = new SelectList(_context.Doljnost, "Id", "Id", employees.Doljnost);
        //    return View(employees);
        //}

        // GET: Employees/Delete/5
        //public async Task<IActionResult> Delete(byte? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employees = await _context.Employees
        //        .Include(e => e.DoljnostNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (employees == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employees);
        //}
        public ActionResult Delete(byte id)
        {
            Employees employees = employeesDataAccessLayer.GetEmployee(id);
               return View(employees);
        }
        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Employees employees)
        {
            try
            {
                // TODO: Add delete logic here  
                employeesDataAccessLayer.DeleteEmployee(employees.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> DeleteConfirmed(byte id)
        //{
        //    var employees = await _context.Employees.FindAsync(id);
        //    _context.Employees.Remove(employees);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool EmployeesExists(byte id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
