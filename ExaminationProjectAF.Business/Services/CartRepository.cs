using ExaminationProjectAF.Business.Interfaces;
using ExaminationProjectAF.Business.Models;

namespace ExaminationProjectAF.Business.Services;

public class CartRepository : ICartRepository
{
    private readonly List<CartItem> _cartItems = [];

    public void AddCartItem(CartItem cartItem)
    {
        var existingItem = _cartItems.FirstOrDefault(x => x.ProductId == cartItem.ProductId);
        if (existingItem != null)
        {
            existingItem.Quantity += cartItem.Quantity;
            existingItem.Price += cartItem.Price;
        }
        else
        {
            _cartItems.Add(cartItem);
        }
    }

    public IEnumerable<CartItem> GetCartItems()
    {
        return _cartItems;
    }

    public void ClearCart()
    {
        _cartItems.Clear();
    }
}
