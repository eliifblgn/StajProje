using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using SecKaliteDb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using System.Data.SqlTypes;
using SecKaliteDb.Migrations;

namespace SecKaliteDb.Controllers
{
    public class UserController : Controller
    {
        private readonly SecKaliteDbDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserController(SecKaliteDbDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        [AllowAnonymous]
        public IActionResult Giris()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Giris(User user)
        {
            if (ModelState.IsValid)
            {
                var username = _context.User.FirstOrDefault(u => u.Username == user.Username);
                if (username != null)
                {
                    var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(username, username.Password, user.Password);


                    if (passwordVerificationResult == PasswordVerificationResult.Success)

                    {
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Username),
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim("Admin", username.Admin.ToString()),
                        //new Claim(ClaimTypes.Email, "email")
                        //new Claim("FullName", user.FullName),
                        
                    };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var authProperties = new AuthenticationProperties
                        {
                            //AllowRefresh = true,
                            // Refreshing the authentication session should be allowed.

                            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                            // The time at which the authentication ticket expires. A 
                            // value set here overrides the ExpireTimeSpan option of 
                            // CookieAuthenticationOptions set with AddCookie.

                            IsPersistent = true,
                            // Whether the authentication session is persisted across 
                            // multiple requests. When used with cookies, controls
                            // whether the cookie's lifetime is absolute (matching the
                            // lifetime of the authentication ticket) or session-based.

                            //IssuedUtc = <DateTimeOffset>,
                            // The time at which the authentication ticket was issued.

                            //RedirectUri = <string>
                            // The full path or absolute URI to be used as an http 
                            // redirect response value.
                        };

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                      new ClaimsPrincipal(claimsIdentity),
                                                      authProperties);

                        return RedirectToAction("Index", "Home");
                    }



                    else
                    {
                        ModelState.AddModelError("Password", "Kullanıcı adı ya da şifresi hatalı !");
                    }


                }

                else
                {
                    ModelState.AddModelError("Username", "Kullanıcı adı ya da şifresi hatalı!");
                }

            }


            return View(user);
        }

        [AllowAnonymous]
        public IActionResult Kaydol()
        {
            return RedirectToAction("Kaydol", "Register");
        }

        public async Task<IActionResult> Cikis()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Giris");
        }
    }
}
