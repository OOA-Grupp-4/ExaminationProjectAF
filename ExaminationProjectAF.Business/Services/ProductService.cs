using ExaminationProjectAF.Business.Enums;
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

    public ProductServiceResult<Product> AddProduct(Product product)
    {
        _productRepository.AddProduct(product);
        return new ProductServiceResult<Product>
        {
            Success = true,
            StatusCode = 200,
            Message = "Product was added successfully",
            Data = product
        };
    }

    public ProductServiceResult<Product> UpdateProduct(Product product)
    {
        var existingProduct = _productRepository.GetProductById(product.Id);
        if (existingProduct == null)
        {
            return new ProductServiceResult<Product>
            {
                Success = false,
                StatusCode = 404,
                Message = "Product was not found",
            };
        }
        else
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.StockStatus = product.StockStatus;

            _productRepository.UpdateProduct(existingProduct);
            return new ProductServiceResult<Product>
            {
                Success = true,
                StatusCode = 200,
                Message = "Product was updated successfully",
                Data = existingProduct
            };
        }
    }

    public ProductServiceResult<bool> DeleteProduct(string productId)
    {
        var success = _productRepository.DeleteProduct(productId);
        return new ProductServiceResult<bool>
        {
            Success = success,
            StatusCode = 200,
            Message = "Product was deleted successfully"
        };
    }

    public ProductServiceResult<Product> UpdateStockStatus(string productId, StockStatus stockStatus)
    {
        var product = _productRepository.GetProductById(productId);
        if (product == null)
        {
            return new ProductServiceResult<Product>
            {
                Success = false,
                StatusCode = 404,
                Message = "Product was not found"
            };
        }
        else
        {
            product.StockStatus = stockStatus;
            _productRepository.UpdateProduct(product);
            return new ProductServiceResult<Product>
            {
                Success = true,
                StatusCode = 200,
                Message = "Stock was updated successfully",
                Data = product
            };
        }
    }
}
