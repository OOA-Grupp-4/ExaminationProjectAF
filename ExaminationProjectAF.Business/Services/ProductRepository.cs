using ExaminationProjectAF.Business.Interfaces;
using ExaminationProjectAF.Business.Models;

namespace ExaminationProjectAF.Business.Services;

public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = [];

    public Product GetProductById(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return null!;
        }
        else
        {
            return _products.FirstOrDefault(x => x.Id == id)!;
        }
    }

    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }
}
