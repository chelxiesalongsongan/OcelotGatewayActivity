using Microsoft.AspNetCore.Mvc;

namespace OrdersService.Controllers;

public class Order
{
    public int Id { get; set; }
    public string ProductName { get; set; } = "";
    public int Quantity { get; set; }
    public string Status { get; set; } = "";
}

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private static readonly List<Order> Orders = new()
    {
        new() { Id = 1, ProductName = "Keyboard", Quantity = 2, Status = "Pending" },
        new() { Id = 2, ProductName = "USB Cable", Quantity = 3, Status = "Processing" }
    };

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Orders);
    }
}
