using ECommerceMVC.Data;
using ECommerceMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly EcommerceMvcContext db;

        public ProductsController(EcommerceMvcContext context) => db  = context;

        
        public async Task<IActionResult> Index(int pageIndex = 1)
        {
            var data = db.Products.Select(e => new ProductsModel
            {
                ProductID = e.ProductId,
                ProductName = e.ProductName,
                ImageUrl = e.Images ?? string.Empty,
                Price = e.Price,
            });
            if(pageIndex < 1) {
                pageIndex = 1;
            }
            return View(await PaginatedList<ProductsModel>.CreatePagination(data, pageIndex));
        }
    }
}
