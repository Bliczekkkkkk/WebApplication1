using Microsoft.AspNetCore.Mvc;
using TwojaAplikacja.Models;
using TwojaAplikacja.Services;

namespace TwojaAplikacja.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        return Ok(_productService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _productService.GetById(id);
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> Add([FromBody] Product product)
    {
        var createdProduct = _productService.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
    }
}