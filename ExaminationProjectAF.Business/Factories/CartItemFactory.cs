using ExaminationProjectAF.Business.Models;

namespace ExaminationProjectAF.Business.Factories;

public static class CartItemFactory
{
    public static CartItem CreateCartItem(CartItemRequest cartItemRequest)
    {
        try
        {
            var cartItem = new CartItem()
            {
                ProductId = cartItemRequest.ProductId,
                Quantity = cartItemRequest.Quantity,
                Price = cartItemRequest.Price
            };

            return cartItem;
        }
        catch
        {
            return null!;
        }
    }
}
