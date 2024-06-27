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
    public class VyplatasController : Controller
    {
        private readonly BusinessContext _context;
        VyplataDataAccessLayer vyplataDataAccessLayer = null;
        
        public VyplatasController(BusinessContext context)
        {
            _context = context;
            vyplataDataAccessLayer = new VyplataDataAccessLayer();
        }

        // GET: Vyplatas
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Vyplata.ToListAsync());
        //}
        public ActionResult Index()
        {
            IEnumerable<Vyplata> vyplata = vyplataDataAccessLayer.GetAllVyplaty();
            return View(vyplata);
        }

        // GET: Vyplatas/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var vyplata = await _context.Vyplata
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (vyplata == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(vyplata);
        //}
        public ActionResult Details(int id)
        {
            Vyplata vyplata = vyplataDataAccessLayer.DetailsVyplaty(id);
            
            return View(vyplata);
        }
        // GET: Vyplatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vyplatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Srok,Oplachivaetsya,Sum,Procent,Procts,Penya,Total,Ostatok")] Vyplata vyplata)
        {

            //if (ModelState.IsValid)
            //{
            //    _context.Add(vyplata);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(vyplata);
            string connectionString = @"Data Source=WIN-FTJ1J5HGOHN\SQLEXPRESS;Initial Catalog=Business;Integrated Security=True";
            string sqlExpression = "SP_Credits";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter empParameter = new SqlParameter
                {
                    ParameterName = "@srok",
                    Value = vyplata.Srok
                };
                command.Parameters.Add(empParameter);
                SqlParameter yearParameter = new SqlParameter
                {
                    ParameterName = "@oplata",
                    Value = vyplata.Oplachivaetsya
                };
                command.Parameters.Add(yearParameter);
                SqlParameter monthParameter = new SqlParameter
                {
                    ParameterName = "@procent",
                    Value = vyplata.Procent
                };
                command.Parameters.Add(monthParameter);
                //var result = command.ExecuteScalar();
                //Debug.WriteLine(result);
                //if (Convert.ToInt32(result) >= 0)
                //{
                //    return true;
                //}
                var result = command.ExecuteNonQuery();
            }
            List<Vyplata> credits = new List<Vyplata>();
            List<Vyplata> list = _context.Vyplata.ToList();
            Vyplata vyplata1 = list.Last();
            //return RedirectToAction("Edit", payroll.id);
            return RedirectToAction("Edit", new RouteValueDictionary(
                new { controller = "Vyplatas", action = "Edit", id = vyplata1.Id })
                );
        }


        // GET: Vyplatas/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var vyplata = await _context.Vyplata.FindAsync(id);
        //    if (vyplata == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(vyplata);
        //}
        public ActionResult Edit(int id)
        {
            Vyplata vyplata = vyplataDataAccessLayer.DetailsVyplaty(id);
            return View(vyplata);
        }
        // POST: Vyplatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        //public async Task<IActionResult> Edit(int id, [Bind("Id,Srok,Oplachivaetsya,Sum,Procent,Procts,Penya,Total,Ostatok")] Vyplata vyplata)
        //{
        //    if (id != vyplata.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(vyplata);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!VyplataExists(vyplata.Id))
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
        //    return View(vyplata);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Vyplata vyplata)
        {
            try
            {
                // TODO: Add update logic here  
                vyplataDataAccessLayer.Updatevyplaty(vyplata);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Vyplatas/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var vyplata = await _context.Vyplata
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (vyplata == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(vyplata);
        //}
        public ActionResult Delete(int id)
        {
            Vyplata vyplata = vyplataDataAccessLayer.DetailsVyplaty(id);
            return View(vyplata);
        }
        // POST: Vyplatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var vyplata = await _context.Vyplata.FindAsync(id);
        //    _context.Vyplata.Remove(vyplata);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        public ActionResult Delete(Vyplata vyplata)
        {
            try
            {
                // TODO: Add delete logic here  
                vyplataDataAccessLayer.DeleteVyplaty(vyplata.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private bool VyplataExists(int id)
        {
            return _context.Vyplata.Any(e => e.Id == id);
        }
    }
}
