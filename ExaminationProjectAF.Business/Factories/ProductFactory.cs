using ExaminationProjectAF.Business.Models;

namespace ExaminationProjectAF.Business.Factories;

public static class ProductFactory
{
    public static Product CreateProduct(ProductRequest productRequest)
    {
        try
        {
            var product = new Product
            {
                Name = productRequest.Name,
                Price = productRequest.Price,
                Category = productRequest.Category,
            };

            return product;
        }
        catch
        {
            return null!;
        }
    }
}
