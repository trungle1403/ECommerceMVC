using ECommerceMVC.Areas.Admin.ViewModels;
using ECommerceMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace ECommerceMVC.Areas.Admin.ViewComponents
{
    public class LeftbarViewComponent : ViewComponent
    {
        private readonly EcommerceMvcContext _context;

        public LeftbarViewComponent(EcommerceMvcContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var data = _context.Menus.Select(e => new LeftbarVM
            {
                MenuID = e.MenuId,
                MenuName = e.MenuName,
                Icon = e.Icon,
                OrderNumber = e.OrderNumber,
                ParentID = e.MenuIdParent,
                IsActive = e.IsActive,
                Url = e.Url,
            }).OrderBy(e => e.OrderNumber);
            return View(data);
        }
    }
}
