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
    public class FinishedProductsController : Controller
    {
        private readonly BusinessContext _context;
        Finished_productsDataAccessLayer finished_ProductsDataAccessLayer = null;
       
        public FinishedProductsController(BusinessContext context)
        {
            _context = context;
            finished_ProductsDataAccessLayer = new Finished_productsDataAccessLayer();
        }

        // GET: FinishedProducts
        //public async Task<IActionResult> Index()
        //{
        //    var businessContext = _context.FinishedProducts.Include(f => f.UnitNavigation);
        //    return View(await businessContext.ToListAsync());
        //}
        public ActionResult Index()
        {
            IEnumerable<FinishedProducts> finishedProducts = finished_ProductsDataAccessLayer.GetAll();
            finishedProducts = _context.FinishedProducts.Include(e => e.UnitNavigation);
            return View(finishedProducts);
        }
        // GET: FinishedProducts/Details/5
        //public async Task<IActionResult> Details(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var finishedProducts = await _context.FinishedProducts
        //        .Include(f => f.UnitNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (finishedProducts == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(finishedProducts);
        //}
        public ActionResult Details(short id)
        {
            FinishedProducts finishedProducts = finished_ProductsDataAccessLayer.GetFinishedProduct(id);
            ViewData["Unit"] = new SelectList(_context.Unit, "Id", "Name", finishedProducts.Unit);

            return View(finishedProducts);
        }
        // GET: FinishedProducts/Create
     
        public IActionResult Create()
        {
            ViewData["Unit"] = new SelectList(_context.Unit, "Id", "Name");
            return View();
        }

        // POST: FinishedProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FinishedProducts finishedProducts)
        {
            try
            {
                finished_ProductsDataAccessLayer.AddFinished_products(finishedProducts);
                
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                return View();
            }
        }
        //public async Task<IActionResult> Create([Bind("Id,Name,Unit,Sum,Quantity")] FinishedProducts finishedProducts)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(finishedProducts);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Unit"] = new SelectList(_context.Unit, "Id", "Id", finishedProducts.Unit);
        //    return View(finishedProducts);
        //}

        // GET: FinishedProducts/Edit/5
        //public async Task<IActionResult> Edit(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var finishedProducts = await _context.FinishedProducts.FindAsync(id);
        //    if (finishedProducts == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["Unit"] = new SelectList(_context.Unit, "Id", "Name", finishedProducts.Unit);
        //    return View(finishedProducts);
        //}
        public ActionResult Edit(short id)
        {
            FinishedProducts finishedProducts = finished_ProductsDataAccessLayer.DetailsFinishedProducts(id);
            ViewData["Unit"] = new SelectList(_context.Unit, "Id", "Name", finishedProducts.Unit);
            return View(finishedProducts);
        }
        // POST: FinishedProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FinishedProducts  finishedProducts)
        {
            try
            {
                // TODO: Add update logic here  
                finished_ProductsDataAccessLayer.UpdateFinished_products(finishedProducts);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> Edit(short id, [Bind("Id,Name,Unit,Sum,Quantity")] FinishedProducts finishedProducts)
        //{
        //    if (id != finishedProducts.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(finishedProducts);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!FinishedProductsExists(finishedProducts.Id))
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
        //    ViewData["Unit"] = new SelectList(_context.Unit, "Id", "Id", finishedProducts.Unit);
        //    return View(finishedProducts);
        //}

        // GET: FinishedProducts/Delete/5
        //public async Task<IActionResult> Delete(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var finishedProducts = await _context.FinishedProducts
        //        .Include(f => f.UnitNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (finishedProducts == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(finishedProducts);
        //}
        public ActionResult Delete(short id)
        {
            FinishedProducts finishedProducts = finished_ProductsDataAccessLayer.GetFinishedProduct(id);
            
            return View(finishedProducts);
        }
        // POST: FinishedProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FinishedProducts finishedProducts)
        {
            try
            {
                // TODO: Add delete logic here  
                finished_ProductsDataAccessLayer.DeleteFinishedProduct(finishedProducts.Id);
            
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> DeleteConfirmed(short id)
        //{
        //    var finishedProducts = await _context.FinishedProducts.FindAsync(id);
        //    _context.FinishedProducts.Remove(finishedProducts);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool FinishedProductsExists(short id)
        {
            return _context.FinishedProducts.Any(e => e.Id == id);
        }
    }
}
