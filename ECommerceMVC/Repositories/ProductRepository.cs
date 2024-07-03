using ECommerceMVC.Data;
using ECommerceMVC.Models;
using ECommerceMVC.Services;

namespace ECommerceMVC.Repositories
{
    public interface IProductRepository : IRepository<Product> {
    
    }
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(EcommerceMvcContext context) : base(context)
        {
        }

       
    }
}
