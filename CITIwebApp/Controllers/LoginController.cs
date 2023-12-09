using CITIwebApp.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CITIwebApp.Controllers
{
    
    public class LoginController : Controller
    {
        private MiContext _context;
        public LoginController(MiContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(string email,string password)
        {
            var usuario = await _context.Usuarios
                            .Where(x => x.Email == email && x.Password == password)
                            .FirstOrDefaultAsync();
            if(usuario!=null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["LoginError"] = "Cuenta o contraseña incorreto, intente de nuevo!!";
                return RedirectToAction("Index");
            }
        }
        public async Task <IActionResult> Logout()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}
