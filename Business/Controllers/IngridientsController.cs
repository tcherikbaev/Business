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
    public class IngridientsController : Controller
    {
        private readonly BusinessContext _context;
        IngridientsDataAccessLayer ingridientsDataAccessLayer = null;
        
        public IngridientsController(BusinessContext context)
        {
            _context = context;
            ingridientsDataAccessLayer = new IngridientsDataAccessLayer();
         
        }

        // GET: Ingridients
        //public async Task<IActionResult> Index()
        //{
        //    var businessContext = _context.Ingridients.Include(i => i.ProductNavigation).Include(i => i.RawProductNavigation);
        //    return View(await businessContext.ToListAsync());
        //}
        public ActionResult Index()
        {
            IEnumerable<Ingridients> ingridients= ingridientsDataAccessLayer.GetAll();
            ingridients = _context.Ingridients.Include(i => i.ProductNavigation).Include(i => i.RawProductNavigation);
            return View(ingridients);
        }
        // GET: Ingridients/Details/5
        //public async Task<IActionResult> Details(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ingridients = await _context.Ingridients
        //        .Include(i => i.ProductNavigation)
        //        .Include(i => i.RawProductNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ingridients == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ingridients);
        //}
        public ActionResult Details(short id)
        {
            Ingridients ingridients = ingridientsDataAccessLayer.GetIngridients(id);
            
            ViewData["Product"] = new SelectList(_context.FinishedProducts, "Id", "Name", ingridients.Product);
            ViewData["RawProduct"] = new SelectList(_context.RawMaterials, "Id", "Name", ingridients.RawProduct);

            return View(ingridients);
        }

        // GET: Ingridients/Create
        public IActionResult Create()
        {
            ViewData["Product"] = new SelectList(_context.FinishedProducts, "Id", "Name");
            ViewData["RawProduct"] = new SelectList(_context.RawMaterials, "Id", "Name");
            return View();
        }

        // POST: Ingridients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ingridients ingridients)
        {
            try
            {
                ingridientsDataAccessLayer.AddIngridients(ingridients);
                

                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                return View();
            }
        }
        //public async Task<IActionResult> Create([Bind("Id,Product,RawProduct,Quntatity")] Ingridients ingridients)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(ingridients);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Product"] = new SelectList(_context.FinishedProducts, "Id", "Id", ingridients.Product);
        //    ViewData["RawProduct"] = new SelectList(_context.RawMaterials, "Id", "Id", ingridients.RawProduct);
        //    return View(ingridients);
        //}

        // GET: Ingridients/Edit/5
        //public async Task<IActionResult> Edit(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ingridients = await _context.Ingridients.FindAsync(id);
        //    if (ingridients == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["Product"] = new SelectList(_context.FinishedProducts, "Id", "Name", ingridients.Product);
        //    ViewData["RawProduct"] = new SelectList(_context.RawMaterials, "Id", "Name", ingridients.RawProduct);
        //    return View(ingridients);
        //}
        public ActionResult Edit(short id)
        {
            Ingridients ingridients = ingridientsDataAccessLayer.DetailsIngridients(id);
            
            ViewData["Product"] = new SelectList(_context.FinishedProducts, "Id", "Name", ingridients.Product);
            ViewData["RawProduct"] = new SelectList(_context.RawMaterials, "Id", "Name", ingridients.RawProduct);
            
            return View(ingridients);
        }

        // POST: Ingridients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ingridients ingridients)
        {
            try
            {
                // TODO: Add update logic here  
                ingridientsDataAccessLayer.UpdateIngridients(ingridients);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> Edit(short id, [Bind("Id,Product,RawProduct,Quntatity")] Ingridients ingridients)
        //{
        //    if (id != ingridients.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(ingridients);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!IngridientsExists(ingridients.Id))
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
        //    ViewData["Product"] = new SelectList(_context.FinishedProducts, "Id", "Id", ingridients.Product);
        //    ViewData["RawProduct"] = new SelectList(_context.RawMaterials, "Id", "Id", ingridients.RawProduct);
        //    return View(ingridients);
        //}

        // GET: Ingridients/Delete/5
        //public async Task<IActionResult> Delete(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ingridients = await _context.Ingridients
        //        .Include(i => i.ProductNavigation)
        //        .Include(i => i.RawProductNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (ingridients == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(ingridients);
        //}
        public ActionResult Delete(short id)
        {
            Ingridients ingridients = ingridientsDataAccessLayer.GetIngridients(id);
           

            return View(ingridients);
        }

        // POST: Ingridients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Ingridients ingridients)
        {
            try
            {
                // TODO: Add delete logic here  
                ingridientsDataAccessLayer.DeleteIngridients(ingridients.Id);
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> DeleteConfirmed(short id)
        //{
        //    var ingridients = await _context.Ingridients.FindAsync(id);
        //    _context.Ingridients.Remove(ingridients);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool IngridientsExists(short id)
        {
            return _context.Ingridients.Any(e => e.Id == id);
        }
    }
}
