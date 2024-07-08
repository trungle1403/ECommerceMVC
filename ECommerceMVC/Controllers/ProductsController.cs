using ECommerceMVC.Data;
using ECommerceMVC.Models;
using ECommerceMVC.Repositories;
using ECommerceMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace ECommerceMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly EcommerceMvcContext db;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;

        public ProductsController(EcommerceMvcContext context, IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            db = context;
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        
        //public async Task<IActionResult> Index(int pageIndex = 1)
        //{
        //    var data = db.Products.Select(e => new ProductsModel
        //    {
        //        ProductID = e.ProductId,
        //        ProductName = e.ProductName,
        //        ImageUrl = e.Images ?? string.Empty,
        //        Price = e.Price,
        //    });
        //    if(pageIndex < 1) {
        //        pageIndex = 1;
        //    }
        //    return View(await PaginatedList<ProductsModel>.CreatePagination(data, pageIndex));
        //}
        public async Task<IActionResult> Index(int pageIndex = 1)
        {
            var data = _productRepository.GetAll();
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
           return View(await PaginatedList<Product>.CreatePagination(data, pageIndex));
        }


        [HttpGet]
        public JsonResult GetAllProducts()
        {
            var data = _productRepository.GetAll();
            return Json(data);
        }

        public JsonResult AddToCart(string id, int quantity = 1)
        {
            try
            {
                if (!String.IsNullOrEmpty(id))
                {
                    var productItem = db.Carts.Where(e => e.ProductId == Guid.Parse(id)).FirstOrDefault();
                    //trường hợp chưa có sản phảm trong cart thì thêm sản phẩm vào
                    if (productItem == null)
                    {
                        var cartItem = new Cart()
                        {
                            CustomerId = null,
                            DateCreated = DateTime.Now,
                            ProductId = Guid.Parse(id),
                            Quantity = quantity
                        };
                        db.Carts.Add(cartItem);
                        db.SaveChanges();
                    }
                    else // ngược lại thì tăng số lượng
                    {
                        productItem.Quantity += quantity;
                        db.SaveChanges();
                    }
                    return Json(new ApiResponse { Message = "Đã thêm sản phẩm vào giỏ hàng!", Data = null, Type = true });
                }
                else
                {
                    return Json(new ApiResponse { Message = "Vui lòng thực hiện lại thao tác", Data = null, Type = false });
                }
            }
            catch (Exception ex)
            {
                return Json(new ApiResponse { Message = ex.Message, Data = null, Type = false });
            }
        }
    }
}
