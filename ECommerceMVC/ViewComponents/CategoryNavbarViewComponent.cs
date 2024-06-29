using ECommerceMVC.Data;
using ECommerceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceMVC.ViewComponents
{
    public class CategoryNavbarViewComponent : ViewComponent
    {
        private readonly EcommerceMvcContext _context;

        public CategoryNavbarViewComponent(EcommerceMvcContext context) => _context = context;
        public IViewComponentResult Invoke()
        {
            var data = _context.Categories.Select(e => new CategorySidebarVM
            {
                CategoryID = e.CategoryId,
                CategoryName = e.CategoryName,
                CategoryCount = e.Products.Count
            }).OrderBy(p=>p.CategoryName);
            return View(data);
        }
    }
}
