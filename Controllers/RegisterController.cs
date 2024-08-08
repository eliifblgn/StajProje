using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using SecKaliteDb.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;



namespace SecKaliteDb.Controllers
{
    public class RegisterController : Controller
    {
         private readonly SecKaliteDbDbContext _context;
         private readonly PasswordHasher<User> _passwordHasher;

        public RegisterController(SecKaliteDbDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        [AllowAnonymous]
        public IActionResult Kaydol()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Kaydol(RegisterRequest registerRequest)
        {
            if(ModelState.IsValid)
            {
                if (_context.User.Any(u => u.Username == registerRequest.Username))
                {
                    ModelState.AddModelError("", "Kullanıcı adı zaten mevcut.");
                    return View(registerRequest);
                }

                if (registerRequest.Password != registerRequest.ConfirmPassword)
                {
                    ModelState.AddModelError("", "Şifre ve şifre onayı eşleşmiyor!");
                    return View(registerRequest);
                }

                var newRegister = new RegisterRequest
                {
                    Username = registerRequest.Username,
                    Password = _passwordHasher.HashPassword(null, registerRequest.Password),
                    TC=registerRequest.TC,
                };

                var user = new User
                {
                    Username = registerRequest.Username,
                    Password = _passwordHasher.HashPassword(null, registerRequest.Password),
                    //TC = registerRequest.TC,
                };

                _context.RegisterRequest.Add(newRegister);
                _context.User.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction("Giris", "User");
            }
           
            return View(registerRequest);
        }
   
    }
}
