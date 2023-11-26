using CarRepairWorkshop.Api.Model;
using CarRepairWorkshop.Contracts.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairWorkshop.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Customer Customer)
    {
        var existingCustomer = await _customerService.Get(Customer.Id);

        if (existingCustomer is not null)
        {
            return Conflict();
        }

        await _customerService.Add(Customer);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingCustomer = await _customerService.Get(id);

        if (existingCustomer is null)
        {
            return NotFound();
        }

        await _customerService.Delete(existingCustomer);

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> Get(int id)
    {
        var existingCustomer = await _customerService.Get(id);

        if (existingCustomer is null)
        {
            return NotFound();
        }

        return Ok(existingCustomer);
    }

    [HttpGet]
    public async Task<ActionResult<List<Customer>>> GetAll()
    {
        var customers = await _customerService.Get();
        return Ok(customers.ToList());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Customer Customer)
    {
        if (id != Customer.Id)
        {
            return BadRequest();
        }

        var existingCustomer = await _customerService.Get(id);

        if (existingCustomer is null)
        {
            return NotFound();
        }

        await _customerService.Update(Customer);

        return Ok();
    }
}