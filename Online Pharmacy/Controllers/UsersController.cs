using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Pharmacy.Data;
using Online_Pharmacy.Models;
using Online_Pharmacy.Views.Users.ViewModel;
using System.Threading.Tasks;

namespace Online_Pharmacy.Controllers
{
    /// <summary>
    /// Manages users in the system.
    /// </summary>
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<SiteUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(ApplicationDbContext context, UserManager<SiteUser> userManager,
           SignInManager<SiteUser> signInManager,
           RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.SiteUsers.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User model)
        {
            var siteUser = new SiteUser
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                FatherName = model.FatherName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                StartingDate = model.StartingDate,
                //role = model.role
            };
            if (ModelState.IsValid)
            {
                var result = await userManager.CreateAsync(siteUser, model.Password);
                await userManager.AddToRoleAsync(siteUser, "User");
                return RedirectToAction(nameof(Index));
            }
            return View(siteUser);
        }
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.SiteUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id = {id} cannot be found";
                return View("Error");
            }

            var model = new User
            {
                UserName = user.Email,
                FirstName = user.FirstName,
                FatherName = user.FatherName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                StartingDate = user.StartingDate,
                //Role = user.Role,
                Password = user.PasswordHash
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id = {model.Id} cannot be found";
                return View("Error");
            }
            else
            {
                user.UserName = model.Email;
                user.FirstName = model.FirstName;
                user.FatherName = model.FatherName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;
                user.StartingDate = model.StartingDate;
                // user.Role = model.Role;


                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Users");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteUser = await _context.SiteUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siteUser == null)
            {
                return NotFound();
            }

            return View(siteUser);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var siteUser = await _context.SiteUsers.FindAsync(id);
            _context.SiteUsers.Remove(siteUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
