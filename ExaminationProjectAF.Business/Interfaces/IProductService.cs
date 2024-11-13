using ExaminationProjectAF.Business.Models;

namespace ExaminationProjectAF.Business.Interfaces;

public interface IProductService
{
    public ProductServiceResult<Product> GetProductById(string productId);
    public ProductServiceResult<IEnumerable<Product>> GetProducts();
}
