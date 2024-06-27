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
    public class ProizvodstvoesController : Controller
    {
        private readonly BusinessContext _context;
        ProizvodstvoDataAccessLayer proizvodstvoDataAccessLayer = null;
        public ProizvodstvoesController(BusinessContext context)
        {
            _context = context;
            proizvodstvoDataAccessLayer = new ProizvodstvoDataAccessLayer();
        }

        // GET: Proizvodstvoes
        //public async Task<IActionResult> Index()
        //{
        //    var businessContext = _context.Proizvodstvo.Include(p => p.EmployeeNavigation).Include(p => p.ProductNavigation);
        //    return View(await businessContext.ToListAsync());
        //}
        public ActionResult Index()
        {
            IEnumerable<Proizvodstvo> proizvodstvo=proizvodstvoDataAccessLayer.GetAll();
            proizvodstvo = _context.Proizvodstvo.Include(p => p.EmployeeNavigation).Include(p => p.ProductNavigation);
            return View(proizvodstvo);
        }
        // GET: Proizvodstvoes/Details/5
        //public async Task<IActionResult> Details(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var proizvodstvo = await _context.Proizvodstvo
        //        .Include(p => p.EmployeeNavigation)
        //        .Include(p => p.ProductNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (proizvodstvo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(proizvodstvo);
        //}
        public ActionResult Details(short id)
        {
            Proizvodstvo proizvodstvo = proizvodstvoDataAccessLayer.GetProizvodstvo(id);
            ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Name", proizvodstvo.Employee);
            ViewData["Product"] = new SelectList(_context.FinishedProducts, "Id", "Name", proizvodstvo.Product);
            return View(proizvodstvo);
        }

        // GET: Proizvodstvoes/Create
        public IActionResult Create()
        {
            ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["Product"] = new SelectList(_context.FinishedProducts, "Id", "Name");
            return View();
        }

        // POST: Proizvodstvoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Product,Amount,Date,Employee")] Proizvodstvo proizvodstvo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Add(proizvodstvo);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            ViewBag.Message = "Not enough raw material to make proizvodstvo. Please back to main menu and change amount";
        //        }
        //    }
        //    ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Id", proizvodstvo.Employee);
        //    ViewData["Product"] = new SelectList(_context.FinishedProducts, "Id", "Id", proizvodstvo.Product);
        //    return View(proizvodstvo);
        //}
        public IActionResult Create(Proizvodstvo proizvodstvo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    proizvodstvoDataAccessLayer.Addproizvodstvo(proizvodstvo);

                    return RedirectToAction(nameof(Index));

                }
                catch (Exception)
                {
                    ViewBag.Message = "Not enough raw material to make proizvodstvo. Please back to main menu and change amount";
                    //return View();
                }
            }
            return View(proizvodstvo);

        }

        // GET: Proizvodstvoes/Edit/5
        //public async Task<IActionResult> Edit(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var proizvodstvo = await _context.Proizvodstvo.FindAsync(id);
        //    if (proizvodstvo == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Name", proizvodstvo.Employee);
        //    ViewData["Product"] = new SelectList(_context.FinishedProducts, "Id", "Name", proizvodstvo.Product);
        //    return View(proizvodstvo);
        //}
        public ActionResult Edit(short id)
        {
            Proizvodstvo proizvodstvo = proizvodstvoDataAccessLayer.Detailsproizvodstvo(id);
            ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Name");
            ViewData["Product"] = new SelectList(_context.FinishedProducts, "Id", "Name");
            return View(proizvodstvo);
        }
        // POST: Proizvodstvoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(short id, [Bind("Id,Product,Amount,Date,Employee")] Proizvodstvo proizvodstvo)
        //{
        //    if (id != proizvodstvo.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(proizvodstvo);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProizvodstvoExists(proizvodstvo.Id))
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
        //    ViewData["Employee"] = new SelectList(_context.Employees, "Id", "Id", proizvodstvo.Employee);
        //    ViewData["Product"] = new SelectList(_context.FinishedProducts, "Id", "Id", proizvodstvo.Product);
        //    return View(proizvodstvo);
        //}

        // GET: Proizvodstvoes/Delete/5
        public ActionResult Edit(Proizvodstvo proizvodstvo)
        {
            try
            {
                // TODO: Add update logic here  
                proizvodstvoDataAccessLayer.Updateproizvodstvo(proizvodstvo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> Delete(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var proizvodstvo = await _context.Proizvodstvo
        //        .Include(p => p.EmployeeNavigation)
        //        .Include(p => p.ProductNavigation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (proizvodstvo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(proizvodstvo);
        //}
        public ActionResult Delete(short id)
        {
            Proizvodstvo proizvodstvo = proizvodstvoDataAccessLayer.GetProizvodstvo(id);
            return View(proizvodstvo);
        }
        // POST: Proizvodstvoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Proizvodstvo proizvodstvo)
        {
            try
            {
                // TODO: Add delete logic here  
                proizvodstvoDataAccessLayer.Deleteproizvodstvo(proizvodstvo.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> DeleteConfirmed(short id)
        //{
        //    var proizvodstvo = await _context.Proizvodstvo.FindAsync(id);
        //    _context.Proizvodstvo.Remove(proizvodstvo);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool ProizvodstvoExists(short id)
        {
            return _context.Proizvodstvo.Any(e => e.Id == id);
        }
    }
}
