﻿namespace ExaminationProjectAF.Business.Models;

public class CartItem
{
    public string Id { get; set; } = null!;
    public string ProductId { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
