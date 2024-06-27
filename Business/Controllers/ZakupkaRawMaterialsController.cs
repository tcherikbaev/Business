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
    public class ZakupkaRawMaterialsController : Controller
    {
        private readonly BusinessContext _context;
        ZakupkaDataAccessLayer zakupkaDataAccessLayer = null;
        public ZakupkaRawMaterialsController(BusinessContext context)
        {
            _context = context;
            zakupkaDataAccessLayer = new ZakupkaDataAccessLayer();
        }

        // GET: ZakupkaRawMaterials
        //public async Task<IActionResult> Index()
        //{
        //    var businessContext = _context.ZakupkaRawMaterial.Include(z => z.EmployeeNavigation).Include(z => z.RawMaterialNavigation);
        //    return View(await businessContext.ToListAsync());
        //}
        public ActionResult Index()
        {
            IEnumerable<ZakupkaRawMaterial> zakupkaRawMaterials = zakupkaDataAccessLayer.GetAll();
            zakupkaRawMaterials = _context.ZakupkaRawMaterial.Include(z => z.EmployeeNavigation).Include(z => z.RawMaterialNavigation);
            return View(zakupkaRawMaterials);
        }
        // GET: ZakupkaRawMaterials/Details/5
        //public async Task<IActionResult> Details(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var zakupkaRawMaterial = await _context.ZakupkaRawMaterial
        //        .Include(z => z.EmployeeNavigation)
        //        .Include(z => z.RawMaterialNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (zakupkaRawMaterial == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(zakupkaRawMaterial);
        //}
        public ActionResult Details(short id)
        {
            ZakupkaRawMaterial zakupkaRawMaterial = zakupkaDataAccessLayer.GetZakupka(id);
            ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Name", zakupkaRawMaterial.Employee);
            ViewData["RawMaterial"] = new SelectList(_context.RawMaterials, "Id", "Name", zakupkaRawMaterial.RawMaterial);
            return View(zakupkaRawMaterial);
        }

        // GET: ZakupkaRawMaterials/Create
        public IActionResult Create()
        {
            ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["RawMaterial"] = new SelectList(_context.RawMaterials, "Id", "Name");
            return View();
        }

        // POST: ZakupkaRawMaterials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,RawMaterial,Amount,Sum,Date,Employee")] ZakupkaRawMaterial zakupkaRawMaterial)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(zakupkaRawMaterial);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //    }
        //    catch
        //    {
        //        ViewBag.Message = "Not enough money in budget.Please try again to create new zakupka and change the sum";
        //    }
        //    ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Id", zakupkaRawMaterial.Employee);
        //    ViewData["RawMaterial"] = new SelectList(_context.RawMaterials, "Id", "Id", zakupkaRawMaterial.RawMaterial);
        //    return View(zakupkaRawMaterial);
        //}
        public IActionResult Create(ZakupkaRawMaterial zakupkaRawMaterial)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    zakupkaDataAccessLayer.Addzakupka(zakupkaRawMaterial);

                    return RedirectToAction(nameof(Index));

                }
                catch (Exception)
                {
                    ViewBag.Message = "Not enough money in budget.Please try again to create new zakupka and change the sum";
                    //return View();
                }
            }
            return View(zakupkaRawMaterial);

        }

        // GET: ZakupkaRawMaterials/Edit/5
        //public async Task<IActionResult> Edit(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var zakupkaRawMaterial = await _context.ZakupkaRawMaterial.FindAsync(id);
        //    if (zakupkaRawMaterial == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Name", zakupkaRawMaterial.Employee);
        //    ViewData["RawMaterial"] = new SelectList(_context.RawMaterials, "Id", "Name", zakupkaRawMaterial.RawMaterial);
        //    return View(zakupkaRawMaterial);
        //}
        public ActionResult Edit(short id)
        {
            ZakupkaRawMaterial zakupkaRawMaterial = zakupkaDataAccessLayer.Detailszakupka(id);
            ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["RawMaterial"] = new SelectList(_context.RawMaterials, "Id", "Name");
            return View(zakupkaRawMaterial);
        }
        // POST: ZakupkaRawMaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ZakupkaRawMaterial zakupkaRawMaterial)
        {
            try
            {
                // TODO: Add update logic here  
                zakupkaDataAccessLayer.Updateproizvodstvo(zakupkaRawMaterial);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> Edit(short id, [Bind("Id,RawMaterial,Amount,Sum,Date,Employee")] ZakupkaRawMaterial zakupkaRawMaterial)
        //{
        //    if (id != zakupkaRawMaterial.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(zakupkaRawMaterial);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ZakupkaRawMaterialExists(zakupkaRawMaterial.Id))
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
        //    ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Id", zakupkaRawMaterial.Employee);
        //    ViewData["RawMaterial"] = new SelectList(_context.RawMaterials, "Id", "Id", zakupkaRawMaterial.RawMaterial);
        //    return View(zakupkaRawMaterial);
        //}

        // GET: ZakupkaRawMaterials/Delete/5
        //public async Task<IActionResult> Delete(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var zakupkaRawMaterial = await _context.ZakupkaRawMaterial
        //        .Include(z => z.EmployeeNavigation)
        //        .Include(z => z.RawMaterialNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (zakupkaRawMaterial == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(zakupkaRawMaterial);
        //}
        public ActionResult Delete(short id)
        {
            ZakupkaRawMaterial zakupkaRawMaterial = zakupkaDataAccessLayer.GetZakupka(id);
            return View(zakupkaRawMaterial);
        }
        // POST: ZakupkaRawMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ZakupkaRawMaterial zakupkaRawMaterial)
        {
            try
            {
                // TODO: Add delete logic here  
                zakupkaDataAccessLayer.Deletezakupka(zakupkaRawMaterial.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //public async Task<IActionResult> DeleteConfirmed(short id)
        //{
        //    var zakupkaRawMaterial = await _context.ZakupkaRawMaterial.FindAsync(id);
        //    _context.ZakupkaRawMaterial.Remove(zakupkaRawMaterial);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool ZakupkaRawMaterialExists(short id)
        {
            return _context.ZakupkaRawMaterial.Any(e => e.Id == id);
        }
    }
}
