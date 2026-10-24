using Microsoft.AspNetCore.Mvc;

namespace ProductsService.Controllers;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> Products = new()
    {
        new() { Id = 1, Name = "Keyboard", Price = 500, Stock = 10 },
        new() { Id = 2, Name = "USB Cable", Price = 100, Stock = 20 }
    };

    [HttpGet]
    public IActionResult GetAll() => Ok(Products);

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public IActionResult Create(Product input)
    {
        input.Id = Products.Count == 0 ? 1 : Products.Max(p => p.Id) + 1;
        Products.Add(input);
        return StatusCode(201, input);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Product input)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();

        product.Name = input.Name;
        product.Price = input.Price;
        product.Stock = input.Stock;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return NotFound();

        Products.Remove(product);
        return NoContent();
    }
}
