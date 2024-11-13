using ExaminationProjectAF.Business.Models;

namespace ExaminationProjectAF.Business.Interfaces;

public interface ICartRepository
{
    public void AddCartItem(CartItem cartItem);
    public IEnumerable<CartItem> GetCartItems();
    public void ClearCart();
}
