using ExaminationProjectAF.Business.Models;

namespace ExaminationProjectAF.Business.Interfaces;

public interface IProductRepository
{
    public Product GetProductById(string id);
    public IEnumerable<Product> GetProducts();
}
