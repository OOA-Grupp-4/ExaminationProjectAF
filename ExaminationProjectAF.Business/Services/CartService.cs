using ExaminationProjectAF.Business.Interfaces;
using ExaminationProjectAF.Business.Models;

namespace ExaminationProjectAF.Business.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IProductService _productService;

    public CartService(ICartRepository cartRepository, IProductService productService)
    {
        _cartRepository = cartRepository;
        _productService = productService;
    }

    public CartServiceResult AddToCart(string productId, int quantity)
    {
        var productResult = _productService.GetProductById(productId);

        if (!productResult.Success || productResult.Data == null)
        {
            return new CartServiceResult
            {
                Success = false,
                StatusCode = 404,
                Message = "Product not found"
            };
        }

        var product = productResult.Data;

        var cartItem = new CartItem
        {
            ProductId = productId,
            Quantity = quantity,
            Price = product.Price * quantity
        };

        _cartRepository.AddCartItem(cartItem);

        return new CartServiceResult
        {
            Success = true,
            StatusCode = 200,
            Message = "Product was added to cart successfully"
        };
    }

    public CartServiceResult<IEnumerable<CartItem>> GetCartItems()
    {
        var cartItems = _cartRepository.GetCartItems();
        if (cartItems == null)
        {
            return new CartServiceResult<IEnumerable<CartItem>>
            {
                Success = false,
                StatusCode = 404,
                Message = "No products were found in cart"
            };
        }
        else
        {
            return new CartServiceResult<IEnumerable<CartItem>>
            {
                Success = true,
                StatusCode = 200,
                Message = "Products were successfully retrieved from cart"
            };
        }
    }

    public CartServiceResult ClearCart()
    {
        _cartRepository.ClearCart();

        return new CartServiceResult
        {
            Success = true,
            StatusCode = 200,
            Message = "Products in cart has been removed"
        };
    }
}
