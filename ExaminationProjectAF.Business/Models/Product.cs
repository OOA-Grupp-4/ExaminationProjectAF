namespace ExaminationProjectAF.Business.Models;

public class Product
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string? Category { get; set; }
}
