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
    public class BanksController : Controller
    {
        private readonly BusinessContext _context;
       
        BankDataAccessLayer bankDataAccessLayer = null;
        public BanksController(BusinessContext context)
        {
            _context = context;
            bankDataAccessLayer = new BankDataAccessLayer();
        }

        // GET: Banks
        //public async Task<IActionResult> Index(string searchString)
        //{


        //    return View(await _context.Bank.ToListAsync());
        //}
        public ActionResult Index()
        {
            IEnumerable<Bank> bank = bankDataAccessLayer.GetAllbank();
            return View(bank);
        }

        // GET: Banks/Details/5
        //public async Task<IActionResult> Details(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var bank = await _context.Bank
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (bank == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(bank);
        //}
        public ActionResult Details(short id)
        {
            Bank bank = bankDataAccessLayer.DetailsBank(id);
            return View(bank);
        }

        // GET: Banks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bank bank)
        {
            try
            {
                bankDataAccessLayer.AddBank(bank);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception)
            {
                return View();
            }
        }
        //public async Task<IActionResult> Create([Bind("Id,Sum,SrokInMonths,ProcentPenya,Ostatok")] Bank bank)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(bank);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(bank);
        //}

        // GET: Banks/Edit/5
        //public async Task<IActionResult> Edit(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var bank = await _context.Bank.FindAsync(id);
        //    if (bank == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(bank);
        //}
        public ActionResult Edit(short id)
        {
            Bank bank = bankDataAccessLayer.DetailsBank(id);
            return View(bank);
        }
        // POST: Banks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bank bank)
        {
            try
            {
                // TODO: Add update logic here  
                bankDataAccessLayer.Updatebank(bank);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> Edit(short id, [Bind("Id,Sum,SrokInMonths,ProcentPenya,Ostatok")] Bank bank)
        //{
        //    if (id != bank.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(bank);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!BankExists(bank.Id))
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
        //    return View(bank);
        //}

        // GET: Banks/Delete/5
        //public async Task<IActionResult> Delete(short? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var bank = await _context.Bank
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (bank == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(bank);
        //}
        public ActionResult Delete(short id)
        {
            Bank bank = bankDataAccessLayer.DetailsBank(id);
            return View(bank);
        }

        // POST: Banks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Bank bank)
        {
            try
            {
                // TODO: Add delete logic here  
                bankDataAccessLayer.Deletebank(bank.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public async Task<IActionResult> DeleteConfirmed(short id)
        //{
        //    var bank = await _context.Bank.FindAsync(id);
        //    _context.Bank.Remove(bank);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool BankExists(short id)
        {
            return _context.Bank.Any(e => e.Id == id);
        }
    }
}
