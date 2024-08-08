using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SecKaliteDb.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SecKaliteDb.Controllers
{
    public class SifreUnuttumController : Controller
    {
        private readonly SecKaliteDbDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public SifreUnuttumController(SecKaliteDbDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        [AllowAnonymous]
        public IActionResult SifreYenileme()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SifreYenileme(SifreUnuttum sifreunuttum)
        {
            if (ModelState.IsValid)
            {
                var register = _context.RegisterRequest.FirstOrDefault(u => u.TC == sifreunuttum.TC);
                if (register == null)
                {
                    ModelState.AddModelError("", "TC Kimilk Numarası Bulunamadı.");
                    return View(sifreunuttum);
                }

                var user = _context.User.FirstOrDefault(u => u.Username == register.Username);
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı Bulunamadı.");
                    return View(sifreunuttum);
                }

                user.Password = _passwordHasher.HashPassword(user, sifreunuttum.Password);

                _context.Update(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Giris", "User");

            }

            return View(sifreunuttum);

        }
    }
}
