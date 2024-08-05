using ECommerceMVC.Common;
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


        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                var data = from cart in _context.Carts
                           join product in _context.Products on cart.ProductId equals product.ProductId
                           select new
                           {
                               cart.CartId,
                               cart.ProductId,
                               cart.Quantity,
                               product.ProductName,
                               product.Price,
                               product.Images,
                           };

                return Json(new ApiResponse { Data = data, Message = MessageNoti.FETCH_SUCCESSFUL, Type = true });
            }
            catch (Exception ex)
            {

                return Json(new ApiResponse { Data = null, Message = ex.Message, Type = false });
            }
        }

        public JsonResult UpdateCart(string id, int quantity = 1)
        {
            try
            {
                if (!String.IsNullOrEmpty(id))
                {
                    var productItem = _context.Carts.Where(e => e.ProductId == Guid.Parse(id)).FirstOrDefault();
                    //trường hợp chưa có sản phảm trong cart thì báo lỗi vì đang ở giỏ hàng
                    if (productItem == null)
                    {
                        return Json(new ApiResponse { Message = "Vui lòng thực hiện lại thao tác!", Data = null, Type = false });

                    }
                    else // ngược lại update số lượng, nếu quantity = 0 thì xóa ra cart
                    {
                        if(quantity != 0)
                        {
                            productItem.Quantity = quantity;
                        }
                        else
                        {
                            _context.Carts.Remove(productItem);
                        }
                        _context.SaveChanges();
                    }
                    return Json(new ApiResponse { Message = "Cập nhật giỏ hàng thành công!", Data = null, Type = true });
                }
                else
                {
                    return Json(new ApiResponse { Message = "Vui lòng thực hiện lại thao tác!", Data = null, Type = false });
                }
            }
            catch (Exception ex)
            {
                return Json(new ApiResponse { Message = ex.Message, Data = null, Type = false });
            }
        }
    }
}
