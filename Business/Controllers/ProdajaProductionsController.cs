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
    public class ProdajaProductionsController : Controller
    {
        private readonly BusinessContext _context;
        ProdajaDataAccessLayer prodajaDataAccessLayer = null;

        public ProdajaProductionsController(BusinessContext context)
        {
            _context = context;
            prodajaDataAccessLayer = new ProdajaDataAccessLayer();
        }

        // GET: ProdajaProductions
        //public async Task<IActionResult> Index()
        //{
        //    var businessContext = _context.ProdajaProduction.Include(p => p.EmployeeNavigation).Include(p => p.ProductionNavigation);
        //    return View(await businessContext.ToListAsync());
        //}
        public ActionResult Index()
        {
            IEnumerable<ProdajaProduction>prodajaProductions = prodajaDataAccessLayer.GetAll();
            prodajaProductions= _context.ProdajaProduction.Include(p => p.EmployeeNavigation).Include(p => p.ProductionNavigation);
            return View(prodajaProductions);
        }
        // GET: ProdajaProductions/Details/5
        //public async Task<IActionResult> Details(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var prodajaProduction = await _context.ProdajaProduction
        //        .Include(p => p.EmployeeNavigation)
        //        .Include(p => p.ProductionNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (prodajaProduction == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(prodajaProduction);
        //}
        public ActionResult Details(short id)
        {
            ProdajaProduction prodajaProduction = prodajaDataAccessLayer.Getprodaja(id);
          
            ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Id", prodajaProduction.Employee);
            ViewData["Production"] = new SelectList(_context.FinishedProducts, "Id", "Id", prodajaProduction.Production);
            return View(prodajaProduction);
        }

        // GET: ProdajaProductions/Create
        public IActionResult Create()
        {
            ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["Production"] = new SelectList(_context.FinishedProducts, "Id", "Name");
            return View();
        }

        // POST: ProdajaProductions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Production,Amount,Sum,Date,Employee")] ProdajaProduction prodajaProduction)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Add(prodajaProduction);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            ViewBag.Message = "Not enough amount of products. Please back to main menu and change amount";
        //        }
        //    }
        //    ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Id", prodajaProduction.Employee);
        //    ViewData["Production"] = new SelectList(_context.FinishedProducts, "Id", "Id", prodajaProduction.Production);
        //    return View(prodajaProduction);
        //}
        public IActionResult Create(ProdajaProduction prodajaProduction)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    prodajaDataAccessLayer.Addprodaja(prodajaProduction);


                    return RedirectToAction(nameof(Index));

                }
                catch (Exception)
                {
                    ViewBag.Message = "Not enough amount of products. Please back to main menu and change amount";
                    //return View();
                }
            }
            return View(prodajaProduction);

        }
        // GET: ProdajaProductions/Edit/5
        //public async Task<IActionResult> Edit(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var prodajaProduction = await _context.ProdajaProduction.FindAsync(id);
        //    if (prodajaProduction == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Name", prodajaProduction.Employee);
        //    ViewData["Production"] = new SelectList(_context.FinishedProducts, "Id", "Name", prodajaProduction.Production);
        //    return View(prodajaProduction);
        //}
        public ActionResult Edit(short id)
        {
            ProdajaProduction prodajaProduction = prodajaDataAccessLayer.Detailsprodaja(id);
            ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["Production"] = new SelectList(_context.FinishedProducts, "Id", "Name");
            return View(prodajaProduction);
        }
        // POST: ProdajaProductions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdajaProduction prodajaProduction)
        {
            try
            {
                // TODO: Add update logic here  
                prodajaDataAccessLayer.Updateprodaja(prodajaProduction);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> Edit(short id, [Bind("Id,Production,Amount,Sum,Date,Employee")] ProdajaProduction prodajaProduction)
        //{
        //    if (id != prodajaProduction.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(prodajaProduction);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProdajaProductionExists(prodajaProduction.Id))
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
        //    ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Id", prodajaProduction.Employee);
        //    ViewData["Production"] = new SelectList(_context.FinishedProducts, "Id", "Id", prodajaProduction.Production);
        //    return View(prodajaProduction);
        //}

        // GET: ProdajaProductions/Delete/5
        //public async Task<IActionResult> Delete(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var prodajaProduction = await _context.ProdajaProduction
        //        .Include(p => p.EmployeeNavigation)
        //        .Include(p => p.ProductionNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (prodajaProduction == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(prodajaProduction);
        //}
        public ActionResult Delete(short id)
        {
            ProdajaProduction prodajaProduction = prodajaDataAccessLayer.Getprodaja(id);
            return View(prodajaProduction);
        }
        // POST: ProdajaProductions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProdajaProduction prodajaProduction)
        {
            try
            {
                // TODO: Add delete logic here  
                prodajaDataAccessLayer.Deletezakupka(prodajaProduction.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> DeleteConfirmed(short id)
        //{
        //    var prodajaProduction = await _context.ProdajaProduction.FindAsync(id);
        //    _context.ProdajaProduction.Remove(prodajaProduction);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool ProdajaProductionExists(short id)
        {
            return _context.ProdajaProduction.Any(e => e.Id == id);
        }
    }
}
