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
    public class RawMaterialsController : Controller
    {
        private readonly BusinessContext _context;
      
        Raw_materials_DataAccessLayer raw_Materials_DataAccessLayer = null;
        public RawMaterialsController(BusinessContext context)
        {
            _context = context;
         
            raw_Materials_DataAccessLayer = new Raw_materials_DataAccessLayer();
        }

        // GET: RawMaterials
        //public async Task<IActionResult> Index()
        //{
        //    var businessContext = _context.RawMaterials.Include(r => r.UnitNavigation);
        //    return View(await businessContext.ToListAsync());
        //}
        public ActionResult Index()
        {
            IEnumerable<RawMaterials> rawMaterials = raw_Materials_DataAccessLayer.GetAll();
       
            rawMaterials = _context.RawMaterials.Include(r => r.UnitNavigation);
            return View(rawMaterials);
        }
        // GET: RawMaterials/Details/5
        //public async Task<IActionResult> Details(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var rawMaterials = await _context.RawMaterials
        //        .Include(r => r.UnitNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (rawMaterials == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(rawMaterials);
        //}
        public ActionResult Details(short id)
        {
            RawMaterials rawMaterials = raw_Materials_DataAccessLayer.GetRawMaterials(id);
            ViewData["Unit"] = new SelectList(_context.Unit, "Id", "Name", rawMaterials.Unit);

            return View(rawMaterials);
        }

        // GET: RawMaterials/Create
        public IActionResult Create()
        {
            ViewData["Unit"] = new SelectList(_context.Unit, "Id", "Name");
            return View();
        }

        // POST: RawMaterials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RawMaterials rawMaterials)
        {
            try
            {
                raw_Materials_DataAccessLayer.AddRaw_materials(rawMaterials);
                

                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                return View();
            }
        }
        //public async Task<IActionResult> Create([Bind("Id,Name,Unit,Sum,Quantity")] RawMaterials rawMaterials)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(rawMaterials);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Unit"] = new SelectList(_context.Unit, "Id", "Id", rawMaterials.Unit);
        //    return View(rawMaterials);
        //}

        // GET: RawMaterials/Edit/5
        //public async Task<IActionResult> Edit(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var rawMaterials = await _context.RawMaterials.FindAsync(id);
        //    if (rawMaterials == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["Unit"] = new SelectList(_context.Unit, "Id", "Name", rawMaterials.Unit);
        //    return View(rawMaterials);
        //}
        public ActionResult Edit(short id)
        {
            RawMaterials rawMaterials = raw_Materials_DataAccessLayer.DetailsRaw_materials(id);
            ViewData["Unit"] = new SelectList(_context.Unit, "Id", "Name", rawMaterials.Unit);
            return View(rawMaterials);
        }

        // POST: RawMaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RawMaterials rawMaterials)
        {
            try
            {
                // TODO: Add update logic here  
                raw_Materials_DataAccessLayer.UpdateRaw_materials(rawMaterials);
              
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> Edit(short id, [Bind("Id,Name,Unit,Sum,Quantity")] RawMaterials rawMaterials)
        //{
        //    if (id != rawMaterials.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(rawMaterials);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!RawMaterialsExists(rawMaterials.Id))
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
        //    ViewData["Unit"] = new SelectList(_context.Unit, "Id", "Id", rawMaterials.Unit);
        //    return View(rawMaterials);
        //}

        // GET: RawMaterials/Delete/5
        //public async Task<IActionResult> Delete(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var rawMaterials = await _context.RawMaterials
        //        .Include(r => r.UnitNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (rawMaterials == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(rawMaterials);
        //}
        public ActionResult Delete(short id)
        {
            RawMaterials rawMaterials = raw_Materials_DataAccessLayer.GetRawMaterials(id);
            

            return View(rawMaterials);
        }

        // POST: RawMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(RawMaterials rawMaterials)
        {
            try
            {
                // TODO: Add delete logic here  
                raw_Materials_DataAccessLayer.DeleteRaw_materials(rawMaterials.Id);
             

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> DeleteConfirmed(short id)
        //{
        //    var rawMaterials = await _context.RawMaterials.FindAsync(id);
        //    _context.RawMaterials.Remove(rawMaterials);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool RawMaterialsExists(short id)
        {
            return _context.RawMaterials.Any(e => e.Id == id);
        }
    }
}
