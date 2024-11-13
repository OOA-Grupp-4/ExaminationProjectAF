using ExaminationProjectAF.Business.Interfaces;
using ExaminationProjectAF.Business.Models;
using ExaminationProjectAF.Business.Services;
using Moq;

namespace ExaminationProjectAF.Tests;

public class CartService_Tests
{
    private readonly Mock<ICartRepository> _cartRepositoryMock;
    private readonly Mock<IProductRepository> _productRepositoryMock;
    private readonly Mock<IProductService> _productServiceMock;
    private readonly Mock<ICartService> _cartServiceMock;
    private readonly CartService _cartService;

    public CartService_Tests()
    {
        _cartRepositoryMock = new Mock<ICartRepository>();
        _productRepositoryMock = new Mock<IProductRepository>();
        _productServiceMock = new Mock<IProductService>();
        _cartServiceMock = new Mock<ICartService>();
        _cartService = new CartService(_cartRepositoryMock.Object, _productServiceMock.Object);
    }

    [Fact]
    public void AddToCart_ShouldReturnTrueWhenProductIsAddedToCart()
    {
        // Arrange
        var productId = "1";
        var quantity = 1;
        var product = new Product { Id = productId, Name = "Phone", Price = 899m, Category = "Phones" };

        var productServiceResult = new ProductServiceResult<Product>
        {
            Success = true,
            StatusCode = 200,
            Message = "Product retrieved successfully",
            Data = product
        };

        _productServiceMock.Setup(x => x.GetProductById(productId)).Returns(productServiceResult);

        CartItem addedCartItem = null!;

        _cartRepositoryMock.Setup(x => x.AddCartItem(It.IsAny<CartItem>())).Callback<CartItem>(x => addedCartItem = x);

        // Act
        var result = _cartService.AddToCart(productId, quantity);

        // Assert
        Assert.True(result.Success);
        Assert.NotNull(addedCartItem);
        Assert.Equal(productId, addedCartItem.ProductId);
        Assert.Equal(quantity, addedCartItem.Quantity);
        Assert.Equal(product.Price * quantity, addedCartItem.Price);
    }


    [Fact]
    public void GetCartItems_ShouldReturnTrueWhenAllItemsAreInCart()
    {
        // Arrange
        var cartItems = new List<CartItem>
        {
            new CartItem { ProductId = "1", Quantity = 1, Price = 899.99m },
            new CartItem { ProductId = "2", Quantity = 2, Price = 299.99m }
        };

        _cartRepositoryMock.Setup(x => x.GetCartItems()).Returns(cartItems);

        var expectedResult = new CartServiceResult<IEnumerable<CartItem>> { Data = cartItems, Success = true };
        _cartServiceMock.Setup(x => x.GetCartItems()).Returns(expectedResult);


        // Act
        var result = _cartServiceMock.Object.GetCartItems();

        // Assert
        Assert.True(result.Success);
        Assert.NotNull(result);
        Assert.NotNull(result.Data);
        Assert.Equal(2, result.Data.Count());
        Assert.Equal(cartItems, result.Data);
    }
}
