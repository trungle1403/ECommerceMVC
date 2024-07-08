using ECommerceMVC.Data;
using ECommerceMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly EcommerceMvcContext _context;

        public IActionResult Index()
        {
            return View();
        }
        public CartController(EcommerceMvcContext context)
        {
            _context = context;
        }
        
    }
}
