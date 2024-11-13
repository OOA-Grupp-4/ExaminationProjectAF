﻿namespace ExaminationProjectAF.Business.Models;

public class ProductRequest
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string? Category { get; set; }
}
