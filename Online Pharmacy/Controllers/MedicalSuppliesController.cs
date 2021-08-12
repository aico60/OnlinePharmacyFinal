using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Pharmacy.Data;
using Online_Pharmacy.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Pharmacy.Controllers
{
    [Authorize(Roles = "Admin,Client,User")]
    public class MedicalSuppliesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicalSuppliesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MedicalSupplies
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedicalSupplies.ToListAsync());
        }

        // GET: MedicalSupplies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalSupply = await _context.MedicalSupplies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalSupply == null)
            {
                return NotFound();
            }

            return View(medicalSupply);
        }

        // GET: MedicalSupplies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MedicalSupplies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Amount,Description,Usage")] MedicalSupply medicalSupply)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalSupply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicalSupply);
        }

        // GET: MedicalSupplies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalSupply = await _context.MedicalSupplies.FindAsync(id);
            if (medicalSupply == null)
            {
                return NotFound();
            }
            return View(medicalSupply);
        }

        // POST: MedicalSupplies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Amount,Description,Usage")] MedicalSupply medicalSupply)
        {
            if (id != medicalSupply.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalSupply);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalSupplyExists(medicalSupply.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medicalSupply);
        }

        // GET: MedicalSupplies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalSupply = await _context.MedicalSupplies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicalSupply == null)
            {
                return NotFound();
            }

            return View(medicalSupply);
        }

        // POST: MedicalSupplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalSupply = await _context.MedicalSupplies.FindAsync(id);
            _context.MedicalSupplies.Remove(medicalSupply);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalSupplyExists(int id)
        {
            return _context.MedicalSupplies.Any(e => e.Id == id);
        }
        [ActionName("Buy")]
        public async Task<IActionResult> Buy(int id)
        {
            var medicalSupply = await _context.MedicalSupplies.FindAsync(id);
            if (medicalSupply == null)
            {
                return NotFound();
            }
            if (!_context.Orders.Any())
            {
                Order order = new Order()
                {
                    OrderCost = medicalSupply.Price,
                    Amount = 1,
                    Date = DateTime.Now,
                    MedicalSupplyName = medicalSupply.Name,
                    UserName = User.Identity.Name
                };
                _context.Add(order);
            }
            else
            {
                if (_context.Orders.Any(x => x.UserName == User.Identity.Name))
                {
                    Order orderToEdit = _context.Orders.FirstOrDefault(x => x.UserName == User.Identity.Name);
                    orderToEdit.OrderCost += medicalSupply.Price;
                    orderToEdit.MedicalSupplyName = (orderToEdit.MedicalSupplyName + ", " + medicalSupply.Name);
                    orderToEdit.OrderCost += medicalSupply.Price;
                    orderToEdit.Date = DateTime.Now;
                }
                else
                {
                    Order order = new Order()
                    {
                        OrderCost = medicalSupply.Price,
                        Amount = 1,
                        Date = DateTime.Now,
                        MedicalSupplyName = medicalSupply.Name,
                        UserName = User.Identity.Name
                    };
                    _context.Add(order);
                }
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Orders");
        }
    }
}
