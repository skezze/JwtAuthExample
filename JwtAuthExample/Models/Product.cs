namespace JwtAuthExample.Models;

public class Product
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public string Manufacturer { get; set; }

    public static Product[] GetArrayProducts()
    {
        return new[]
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                Price = 100,
                Manufacturer = "gigabyte"
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Price = 150,
                Manufacturer = "asus"
            },
            new Product()
            {
                Id = Guid.NewGuid(),
                Price = 250,
                Manufacturer = "palit"
            }
        };
    }
}
