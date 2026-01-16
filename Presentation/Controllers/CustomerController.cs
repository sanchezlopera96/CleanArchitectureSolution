using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _repository;

    public CustomerController(ICustomerRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var customers = _repository.GetAll();
        return Ok(customers);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Customer customer)
    {
        _repository.Add(customer);
        _repository.SaveChanges();
        return CreatedAtAction(nameof(GetAll), customer);
    }
}