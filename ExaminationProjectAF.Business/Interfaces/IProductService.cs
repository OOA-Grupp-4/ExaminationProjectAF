using ExaminationProjectAF.Business.Enums;
using ExaminationProjectAF.Business.Models;

namespace ExaminationProjectAF.Business.Interfaces;

public interface IProductService
{
    public ProductServiceResult<Product> GetProductById(string productId);
    public ProductServiceResult<IEnumerable<Product>> GetProducts();
    public ProductServiceResult<Product> AddProduct(Product product);
    public ProductServiceResult<Product> UpdateProduct(Product product);
    public ProductServiceResult<bool> DeleteProduct(string productId);
    public ProductServiceResult<Product> UpdateStockStatus(string productId, StockStatus stockStatus);
}
