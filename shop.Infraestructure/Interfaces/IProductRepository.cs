using shop.Domain.Entities.Products;
using shop.Domain.Repository;
using shop.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace shop.Infraestructure.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        List<ProductModel> GetProducts();
        ProductModel GetProductId(int id);
    }
}
