namespace ExaminationProjectAF.Business.Models;

public class CartItemRequest
{
    public string ProductId { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
