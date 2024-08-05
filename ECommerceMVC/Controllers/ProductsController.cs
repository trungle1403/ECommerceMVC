using ECommerceMVC.Common;
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
        public async Task<IActionResult> Index(string category = "", string price = "", int pageIndex = 1)
        {
            var data = _productRepository.GetAll();
            if (data.Count() != 0)
            {
                if(category != "")
                {
                    data = data.Where(e => category.Contains(e.CategoryId.ToString()));
                }
                switch (price)
                {
                    case "duoi-5":
                        data = data.Where(e => e.Price < 5000000);
                        break;
                    case "5-10":
                        data = data.Where(e => e.Price >= 5000000 && e.Price <= 10000000);
                        break;
                    case "10-15":
                        data = data.Where(e => e.Price >= 10000000 && e.Price <= 15000000);
                        break;
                    case "15-20":
                        data = data.Where(e => e.Price >= 15000000 && e.Price <= 20000000);
                        break;
                    case "tren-20":
                        data = data.Where(e => e.Price >= 20000000);
                        break;
                }
            }
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
           return View(await PaginatedList<Product>.CreatePagination(data, pageIndex));
        }

        
        [HttpGet]
        public JsonResult GetAllProducts(string category = "", string price = "", int pageIndex = 1)
        {
            //var data = _productRepository.GetAll();
            var data = _productRepository.GetAll();
            if (data.Count() != 0)
            {
                if (category != "")
                {
                    data = data.Where(e => category.Contains(e.CategoryId.ToString()));
                }
                switch (price)
                {
                    case "duoi-5":
                        data = data.Where(e => e.Price < 5000000);
                        break;
                    case "5-10":
                        data = data.Where(e => e.Price >= 5000000 && e.Price <= 10000000);
                        break;
                    case "10-15":
                        data = data.Where(e => e.Price >= 10000000 && e.Price <= 15000000);
                        break;
                    case "15-20":
                        data = data.Where(e => e.Price >= 15000000 && e.Price <= 20000000);
                        break;
                    case "tren-20":
                        data = data.Where(e => e.Price >= 20000000);
                        break;
                }
            }
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            int pageSize = 5;
            int totalCount = data.Count();
            data = data.Skip(pageSize*(pageIndex-1)).Take(pageSize);
            return Json( new ApiResponse { Message = totalCount.ToString(), Data = data, Type = true});
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

        public ActionResult Detail(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var product = _productRepository.GetByID(id);
                if (product == null)
                {
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}
