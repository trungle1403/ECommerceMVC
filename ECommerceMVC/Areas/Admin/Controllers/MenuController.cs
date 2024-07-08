using ECommerceMVC.Common;
using ECommerceMVC.Data;
using ECommerceMVC.Models;
using ECommerceMVC.Repositories;
using ECommerceMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ECommerceMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly EcommerceMvcContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMenuRepository _repository;

        public MenuController(EcommerceMvcContext context, IMenuRepository repository, IUnitOfWork unitOfWork) { 
            _context = context;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public IActionResult Index()
        {
            ViewBag.MenuSelectList = MenuSelectList(null);
            return View();
        }

        [HttpGet]
        public JsonResult GetAllMenu()
        {
            //var data = _repository.GetAll().ToList();
            var data = _context.Menus.Select(c => new
            {
                c.MenuId,
                c.MenuName,
                c.Url,
                c.IsActive,
                c.Icon,
                MenuParent = c.MenuIdParent.HasValue ? _context.Menus.Where(p => p.MenuId == c.MenuIdParent).Select(p => p.MenuName).FirstOrDefault() : null,
            });
            return Json(new ApiResponse { Message = MessageNoti.FETCH_SUCCESSFUL, Data = data, Type = true});
        }

        [HttpGet]
        public JsonResult GetMenuByID(string id)
        {
            var data = _repository.GetByID(id);
            return Json(data);
        }

        [HttpGet]
        public JsonResult SaveInfo(Menu menu)
        {
            //if(ModelState.IsValid)
            //{
                if(menu.MenuId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
                {
                    var data = _repository.Create(menu);
                    _unitOfWork.Commit();
                    return Json(new ApiResponse { Message = MessageNoti.ADD_SUCCESSFUL, Data = data, Type = true });
                }
                else
                {
                    _repository.Update(menu);
                    _unitOfWork.Commit();
                    return Json(new ApiResponse { Message = MessageNoti.UPDATE_SUCCESSFUL, Data = menu, Type = true });
                }
               
            //}
            //else
            //{
            //    return Json( new ApiReponse { Message = MessageNoti.ERROR, Data = null,  Type = false});
            //}
        }

        public JsonResult Delete(string id)
        {
            if (id != null)
            {
                _repository.Delete(id);
                return Json(new ApiResponse { Message = MessageNoti.DELETE_SUCCESSFUL, Data = null, Type = true });
            }
            else
            {
                return Json(new ApiResponse { Message = MessageNoti.ERROR, Data = null, Type = false });
            }
        }

        public SelectList MenuSelectList(string? id)
        {
            var menus = _context.Menus
                .Select(e => new
            {
                e.MenuId,
                e.MenuName,
            });
            if(id != null)
            {
                menus = menus.Where(e => e.MenuId != Guid.Parse(id));
            }
            return new SelectList(menus, "MenuId", "MenuName");
        }
    }
}
