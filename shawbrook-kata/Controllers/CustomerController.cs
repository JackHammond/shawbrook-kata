using Microsoft.AspNetCore.Mvc;
using shawbrook_kata.Interfaces.Services;
using shawbrook_kata.Models.Interfaces;

namespace shawbrook_kata.Controllers
{
    [ApiController]
    [Route("api/v1/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Get customer by ID.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <returns>The customer object.</returns>
        [HttpGet("{id}", Name = "GetCustomer")]
        [ProducesResponseType(typeof(ICustomer), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ICustomer>> GetCustomer(Guid id)
        {
            ICustomer? customer = await _customerService.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}