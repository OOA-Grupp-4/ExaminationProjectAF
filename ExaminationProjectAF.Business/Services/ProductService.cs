using ExaminationProjectAF.Business.Interfaces;
using ExaminationProjectAF.Business.Models;

namespace ExaminationProjectAF.Business.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public ProductServiceResult<Product> GetProductById(string productId)
    {
        var product = _productRepository.GetProductById(productId);
        if (product == null)
        {
            return new ProductServiceResult<Product>
            {
                Success = false,
                StatusCode = 404,
                Message = "Product not found"
            };
        }
        else
        {
            return new ProductServiceResult<Product>
            {
                Success = true,
                StatusCode = 200,
                Message = "Product was retrieved successfully",
                Data = product
            };
        }
    }

    public ProductServiceResult<IEnumerable<Product>> GetProducts()
    {
        var products = _productRepository.GetProducts();

        return new ProductServiceResult<IEnumerable<Product>>
        {
            Success = true,
            StatusCode = 200,
            Message = "All products was retrieved successfully",
            Data = products
        };
    }
}
