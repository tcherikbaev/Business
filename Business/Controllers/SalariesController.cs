using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Business.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Routing;
namespace Business.Controllers
{
    public class SalariesController : Controller
    {
        private readonly BusinessContext _context;
        SalaryDataAccessLayer salaryDataAccessLayer = null;
        public SalariesController(BusinessContext context)
        {
            _context = context;
            salaryDataAccessLayer = new SalaryDataAccessLayer();
        }

        // GET: Salaries
        //public async Task<IActionResult> Index()
        //{
        //    var businessContext = _context.Salary.Include(s => s.MonthNavigation).Include(s => s.NameNavigation).Include(s => s.YearNavigation);
        //    return View(await businessContext.ToListAsync());
        //}
        public ActionResult Index()
        {
            IEnumerable<Salary> salaries = salaryDataAccessLayer.GetAll();
            salaries = _context.Salary.Include(s => s.MonthNavigation).Include(s => s.NameNavigation).Include(s => s.YearNavigation);
            return View(salaries);
        }
        // GET: Salaries/Details/5
        //public async Task<IActionResult> Details(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var salary = await _context.Salary
        //        .Include(s => s.MonthNavigation)
        //        .Include(s => s.NameNavigation)
        //        .Include(s => s.YearNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (salary == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(salary);
        //}
        public ActionResult Details(short id)
        {
            Salary salary = salaryDataAccessLayer.GetSalary(id);
            ViewData["Month"] = new SelectList(_context.Month, "Id", "Month1", salary.Month);
             ViewData["Name"] = new SelectList(_context.Employees, "Id", "Name", salary.Name);
             ViewData["Year"] = new SelectList(_context.Year, "Id", "Id", salary.Year);

            return View(salary);
        }
        // GET: Salaries/Create
        public IActionResult Create()
        {
            ViewData["Month"] = new SelectList(_context.Month, "Id", "Month1");
            ViewData["Name"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["Year"] = new SelectList(_context.Year, "Id", "Id");
            return View();
        }

        // POST: Salaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Year,Month,Date,Oklad,CountStake,Bonus,Premia,Total")] Salary salary)
        {
            //    if (ModelState.IsValid)
            //    {
            //        _context.Add(salary);
            //        await _context.SaveChangesAsync();
            //        return RedirectToAction(nameof(Index));
            //    }
            //    ViewData["Month"] = new SelectList(_context.Month, "Id", "Id", salary.Month);
            //    ViewData["Name"] = new SelectList(_context.Employees, "Id", "Id", salary.Name);
            //    ViewData["Year"] = new SelectList(_context.Year, "Id", "Id", salary.Year);
            //    return View(salary);
            //}
            string connectionString = @"Data Source=WIN-FTJ1J5HGOHN\SQLEXPRESS;Initial Catalog=Business;Integrated Security=True";
            string sqlExpression = "SP_Salary";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter empParameter = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = salary.Name
                };
                command.Parameters.Add(empParameter);
                SqlParameter yearParameter = new SqlParameter
                {
                    ParameterName = "@year",
                    Value = salary.Year
                };
                command.Parameters.Add(yearParameter);
                SqlParameter monthParameter = new SqlParameter
                {
                    ParameterName = "@month",
                    Value = salary.Month
                };
                command.Parameters.Add(monthParameter);

                var result = command.ExecuteNonQuery();
            }
            List<Salary> salaries = new List<Salary>();
            List<Salary> list = _context.Salary.ToList();
            Salary salary1 = list.Last();
            //return RedirectToAction("Edit", payroll.id);
            return RedirectToAction("Edit", new RouteValueDictionary(
                new { controller = "Salaries", action = "Edit", id = salary1.Id })
                );
        }
        // GET: Salaries/Edit/5
        //    public async Task<IActionResult> Edit(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var salary = await _context.Salary.FindAsync(id);
        //    if (salary == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["Month"] = new SelectList(_context.Month, "Id", "Month1", salary.Month);
        //    ViewData["Name"] = new SelectList(_context.Employees, "Id", "Name", salary.Name);
        //    ViewData["Year"] = new SelectList(_context.Year, "Id", "Id", salary.Year);
        //    return View(salary);
        //}
        public ActionResult Edit(short id)
        {
            Salary salary = salaryDataAccessLayer.Detailssalary(id);
            ViewData["Month"] = new SelectList(_context.Month, "Id", "Month1", salary.Month);
             ViewData["Name"] = new SelectList(_context.Employees, "Id", "Name", salary.Name);
             ViewData["Year"] = new SelectList(_context.Year, "Id", "Id", salary.Year);          
            return View(salary);
        }
        // POST: Salaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(short id, [Bind("Id,Name,Year,Month,Date,Oklad,CountStake,Bonus,Premia,Total")] Salary salary)
        //{
        //    if (id != salary.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(salary);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SalaryExists(salary.Id))
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
        //    ViewData["Month"] = new SelectList(_context.Month, "Id", "Month1", salary.Month);
        //    ViewData["Name"] = new SelectList(_context.Employees, "Id", "Name", salary.Name);
        //    ViewData["Year"] = new SelectList(_context.Year, "Id", "Id", salary.Year);
        //    return View(salary);
        //}
        public ActionResult Edit(Salary salary)
        {
            try
            {
                salaryDataAccessLayer.Updatesalary(salary);
                // TODO: Add update logic here  
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: Salaries/Delete/5
        //public async Task<IActionResult> Delete(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var salary = await _context.Salary
        //        .Include(s => s.MonthNavigation)
        //        .Include(s => s.NameNavigation)
        //        .Include(s => s.YearNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (salary == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(salary);
        //}
        public ActionResult Delete(short id)
        {
            Salary salary = salaryDataAccessLayer.GetSalary(id);
            return View(salary);
        }
        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(short id)
        //{
        //    var salary = await _context.Salary.FindAsync(id);
        //    _context.Salary.Remove(salary);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        public ActionResult Delete(Salary salary)
        {
            try
            {
                // TODO: Add delete logic here  
                salaryDataAccessLayer.Deletesalary(salary.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private bool SalaryExists(short id)
        {
            return _context.Salary.Any(e => e.Id == id);
        }
    }
}
