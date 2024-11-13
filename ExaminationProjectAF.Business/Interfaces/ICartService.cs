using ExaminationProjectAF.Business.Models;

namespace ExaminationProjectAF.Business.Interfaces;

public interface ICartService
{
    public CartServiceResult AddToCart(string productId, int quantity);
    public CartServiceResult<IEnumerable<CartItem>> GetCartItems();
    public CartServiceResult ClearCart();
}
