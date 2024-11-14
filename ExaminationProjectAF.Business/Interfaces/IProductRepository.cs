using ExaminationProjectAF.Business.Models;

namespace ExaminationProjectAF.Business.Interfaces;

public interface IProductRepository
{
    public Product GetProductById(string id);
    public IEnumerable<Product> GetProducts();
    public void AddProduct(Product product);
    public void UpdateProduct(Product product);
    public bool DeleteProduct(string productId);
}
