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

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        var index = _products.FindIndex(x => x.Id == product.Id);
        if (index != -1)
        {
            _products[index] = product;
        }
    }

    public bool DeleteProduct(string productId)
    {
        var product = _products.FirstOrDefault(x => x.Id == productId);
        if (product == null)
        {
            return false;
        }
        else
        {
            _products.Remove(product);
            return true;
        }
    }



}
