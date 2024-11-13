﻿using ExaminationProjectAF.Business.Interfaces;
using ExaminationProjectAF.Business.Models;
using ExaminationProjectAF.Business.Services;
using Moq;

namespace ExaminationProjectAF.Tests;

public class ProductService_Tests
{
    private readonly Mock<IProductRepository> _productrepositoryMock;
    private readonly ProductService _productService;

    public ProductService_Tests()
    {
        _productrepositoryMock = new Mock<IProductRepository>();
        _productService = new ProductService(_productrepositoryMock.Object);
    }


    [Fact]
    public void GetProductById_ShouldReturnProduct_WhenProductExists()
    {
        // Arrange
        var productId = "1";
        var expectedProduct = new Product { Id = productId, Name = "IPhone", Price = 899.99m, Category = "Phones" };

        _productrepositoryMock.Setup(x => x.GetProductById(productId)).Returns(expectedProduct);

        // Act
        var result = _productService.GetProductById(productId);

        // Assert
        Assert.True(result.Success);
        Assert.NotNull(result.Data);
        Assert.Equal(expectedProduct.Id, result.Data.Id);
        Assert.Equal(expectedProduct.Name, result.Data.Name);
        Assert.Equal(expectedProduct.Price, result.Data.Price);
        Assert.Equal(expectedProduct.Category, result.Data.Category);
    }


    [Fact]
    public void GetProducts_ShouldReturnProductList()
    {
        // Arrange
        var products = new List<Product>()
        {
            new Product { Id = "1", Name = "IPhone", Price = 899.99m, Category = "Phones" },
            new Product { Id = "2", Name = "Laptop", Price = 1999.99m, Category = "Computers" }
        };

        _productrepositoryMock.Setup(x => x.GetProducts()).Returns(products);

        // Act
        var result = _productService.GetProducts();

        // Assert
        Assert.True(result.Success);
        Assert.NotNull(result.Data);
        Assert.Equal(2, result.Data.Count());
        Assert.Contains(result.Data, x => x.Name == "IPhone");
        Assert.Contains(result.Data, x => x.Name == "Laptop");
    }
}