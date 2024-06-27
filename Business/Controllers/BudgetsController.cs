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
    public class BudgetsController : Controller
    {
        BudgetDataAccessLayer budgetDataAccessLayer = null;
        public BudgetsController()
        {
            budgetDataAccessLayer = new BudgetDataAccessLayer();
        }
        private readonly BusinessContext _context;

        //public BudgetsController(BusinessContext context)
        //{
        //    _context = context;
        //}

        // GET: Budgets
        public ActionResult Index()
        {
            IEnumerable<Budget> budgets = budgetDataAccessLayer.GetAllbudget();
            return View(budgets);
        }
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Budget.ToListAsync());
        //}


        //public async Task<IActionResult> Details(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var budget = await _context.Budget
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (budget == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(budget);
        //}
        public ActionResult Details(short id)
        {
            Budget budget = budgetDataAccessLayer.DetailsBudget(id);
            return View(budget);
        }

        // GET: Budgets/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Budget budget)
        {
            try
            {
                budgetDataAccessLayer.Addbudget(budget);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                return View();
            }
        }

        //public async Task<IActionResult> Create([Bind("Id,SumOfBudget,PremiaProcent,Nadbavka")] Budget budget)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(budget);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(budget);
        //}



        //public async Task<IActionResult> Edit(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var budget = await _context.Budget.FindAsync(id);
        //    if (budget == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(budget);
        //}
        public ActionResult Edit(short id)
        {
            Budget budget = budgetDataAccessLayer.DetailsBudget(id);
            return View(budget);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Budget budget)
        {
            try
            {
                // TODO: Add update logic here  
                budgetDataAccessLayer.Updatebudget(budget);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> Edit(short id, [Bind("Id,SumOfBudget,PremiaProcent,Nadbavka")] Budget budget)
        //{
        //    if (id != budget.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(budget);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BudgetExists(budget.Id))
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
        //    return View(budget);
        //}

        public ActionResult Delete(short id)
        {
            Budget budget = budgetDataAccessLayer.DetailsBudget(id);
            return View(budget);
        }
        //public async Task<IActionResult> Delete(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var budget = await _context.Budget
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (budget == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(budget);
        //}

        // POST: Budgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Budget budget)
        {
            try
            {
                // TODO: Add delete logic here  
                budgetDataAccessLayer.Deletebudget(budget.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> DeleteConfirmed(short id)
        //{
        //    var budget = await _context.Budget.FindAsync(id);
        //    _context.Budget.Remove(budget);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool BudgetExists(short id)
        {
            return _context.Budget.Any(e => e.Id == id);
        }
    }
}
